using AutoMapper;
using PIMTool.Core.Domain.Entities;
using PIMTool.Core.Dtos.Response;
using PIMTool.Core.Interfaces.Repositories;
using PIMTool.Core.Interfaces.Services;

namespace PIMTool.Services
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> _repository;
        private readonly IMapper _mapper;

        public GroupService(IRepository<Group> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GroupResponse>> GetAll()
        {
            var groups = await _repository.GetAsync(includeProperties: $"{nameof(Group.GroupLeader)}");
            return _mapper.Map<IEnumerable<GroupResponse>>( groups );
        }
    }
}
