using Microsoft.EntityFrameworkCore;
using PIMTool.Core.Domain.Entities;
using PIMTool.Core.Interfaces.Repositories;
using PIMTool.Database;
using System.Linq.Expressions;

namespace PIMTool.Repositories
{
    public class ProjectEmployeeRepository: IProjectEmployeeRepository
    {
        private readonly PimContext _pimContext;
        private readonly DbSet<ProjectEmployee> _set;

        public ProjectEmployeeRepository(PimContext pimContext)
        {
            _pimContext = pimContext;
            _set = _pimContext.ProjectEmployees;
        }

        public async Task AddAsync(ProjectEmployee projectEmployee)
        {
            await _set.AddAsync(projectEmployee);
        }

        public async Task AddRangeAsync(IEnumerable<ProjectEmployee> entities)
        {
            await _set.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<ProjectEmployee>> GetAsync(Expression<Func<ProjectEmployee, bool>>? filter = null, string includeProperties = "", Func<IQueryable<ProjectEmployee>, IOrderedQueryable<ProjectEmployee>>? orderBy = null)
        {
            IQueryable<ProjectEmployee> query = _set;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (string property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _pimContext.SaveChangesAsync();
        }
    }
}
