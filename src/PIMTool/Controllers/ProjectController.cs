using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PIMTool.Core.Dtos.Requests;
using PIMTool.Core.Interfaces.Services;
using PIMTool.Dtos.Requests;
using PIMTool.Dtos.Response;

namespace PIMTool.Controllers
{
    [ApiController]
    [Route("api/v1/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService,
            IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectResponse>> Get([FromRoute][Required]decimal id)
        {
            var entity = await _projectService.GetAsync(id);
            return Ok(entity);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetAll([FromQuery] ProjectFilterRequest? filter)
        {
            var projects = await _projectService.GetAllAsync(filter);
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectCreateRequest request)
        {
            await _projectService.Create(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] decimal id, [FromBody] ProjectUpdateRequest request)
        {
            await _projectService.Update(id, request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] decimal id)
        {
            await _projectService.Delete(id);
            return Ok();
        }
    }
}