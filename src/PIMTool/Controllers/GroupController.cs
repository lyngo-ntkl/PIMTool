using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIMTool.Core.Dtos.Response;
using PIMTool.Core.Interfaces.Services;

namespace PIMTool.Controllers
{
    [Route("api/v1/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _service;

        public GroupController(IGroupService groupService)
        {
            _service = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupResponse>>> GetAll()
        {
            var groups = await _service.GetAll();
            return Ok(groups);
        }
    }
}
