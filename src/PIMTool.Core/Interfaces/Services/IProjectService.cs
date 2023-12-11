using PIMTool.Core.Domain.Entities;
using PIMTool.Core.Dtos.Requests;
using PIMTool.Dtos.Requests;
using PIMTool.Dtos.Response;

namespace PIMTool.Core.Interfaces.Services
{
    public interface IProjectService
    {
        Task<ProjectResponse?> GetAsync(decimal id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProjectResponse>> GetAllAsync(ProjectFilterRequest filter);
        Task Create(ProjectCreateRequest request);
        Task Update(decimal id, ProjectUpdateRequest request, CancellationToken cancellationToken = default);
        Task Delete(decimal id, CancellationToken cancellationToken = default);
    }
}