using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PIMTool.Core.Domain.Entities;
using PIMTool.Core.Domain.Enums;
using PIMTool.Core.Dtos.Requests;
using PIMTool.Core.Exceptions;
using PIMTool.Core.Interfaces.Repositories;
using PIMTool.Core.Interfaces.Services;
using PIMTool.Dtos;
using PIMTool.Dtos.Requests;
using PIMTool.Dtos.Response;
using PIMTool.Utils;
using System.Linq.Expressions;
using System.Threading;

namespace PIMTool.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _repository;
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public ProjectService(IRepository<Project> repository, IMapper mapper, IProjectEmployeeRepository projectEmployeeRepository, IRepository<Employee> employeeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _projectEmployeeRepository = projectEmployeeRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<ProjectResponse?> GetAsync(decimal id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            var members = _projectEmployeeRepository.GetAsync(filter: x => x.ProjectId == id).Result.Select(x => x.EmployeeId);
            var result = _mapper.Map<ProjectResponse>(entity);
            result.Members = members;
            return result;
        }

        public async Task<IEnumerable<ProjectResponse>> GetAllAsync(ProjectFilterRequest? filter)
        {
            Expression expression = Expression.Constant(true);
            var parameters = Expression.Parameter(typeof(Project));
            if(filter != null)
            {
                if(filter.Status != null)
                {
                    expression = Expression.And(expression, 
                        Expression.Equal(
                            Expression.Property(parameters, nameof(Project.Status)), 
                            Expression.Constant(filter.Status.ToString())));
                }
                if(filter.GlobalFilter != null)
                {
                    var globalFilter = Expression.Constant(filter.GlobalFilter);
                    var tmpExpression = Expression.Or(
                            ExpressionUtils.StringContains<Project>(
                                stringValue: globalFilter,
                                stringInstance: Expression.Property(parameters, nameof(Project.Name))),
                            ExpressionUtils.StringContains<Project>(
                                stringValue: globalFilter,
                                stringInstance: Expression.Property(parameters, nameof(Project.Customer))));
                    if(decimal.TryParse(filter.GlobalFilter, out decimal projectNumber))
                    {
                        tmpExpression = Expression.Or(
                            tmpExpression,
                            Expression.Equal(
                                Expression.Constant(projectNumber),
                                Expression.Property(parameters, nameof(Project.ProjectNumber)))
                            );
                    }
                    expression = Expression.And(expression, tmpExpression);
                }
            }
            var projects = await _repository.GetAsync(filter: Expression.Lambda<Func<Project, bool>>(expression, parameters));
            return _mapper.Map<IEnumerable<ProjectResponse>>(projects);
        }

        public async Task Create(ProjectCreateRequest request)
        {
            if(_repository.Get().FirstOrDefault(x => x.ProjectNumber == request.ProjectNumber) != null)
            {
                throw new Exception("Project number has already exist");
            }
            await _repository.AddAsync(_mapper.Map<Project>(request));
            await _repository.SaveChangesAsync();

            decimal projectId = _repository.Get().FirstOrDefaultAsync(x => x.ProjectNumber == request.ProjectNumber).Result.Id;
            //IEnumerable<ProjectEmployee> employees = new List<ProjectEmployee>();
            foreach(decimal id in request.Members)
            {
                if(_employeeRepository.GetAsync(id).Result == null)
                {
                    throw new Exception($"Employee with id {id} doesn't exist");
                }
                await _projectEmployeeRepository.AddAsync(new ProjectEmployee { ProjectId = projectId, EmployeeId = id });
                await _projectEmployeeRepository.SaveChangesAsync();
            }
        }

        public async Task Update(decimal id, ProjectUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            entity = _mapper.Map(request, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
            foreach (decimal employeeId in request.Members)
            {
                if(_projectEmployeeRepository.GetAsync(x => x.ProjectId == id && x.EmployeeId == employeeId).Result.FirstOrDefault() == null)
                {
                    if (_employeeRepository.GetAsync(employeeId).Result == null)
                    {
                        throw new Exception($"Employee with id {employeeId} doesn't exist");
                    }
                    await _projectEmployeeRepository.AddAsync(new ProjectEmployee { ProjectId = id, EmployeeId = employeeId });
                    await _projectEmployeeRepository.SaveChangesAsync();
                }
            }
        }

        public async Task Delete(decimal id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            if(entity.Status != nameof(ProjectStatus.NEW))
            {
                throw new Exception($"Can't delete {entity.Status} projects");
            }
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }
    }
}