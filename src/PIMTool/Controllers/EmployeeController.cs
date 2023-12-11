using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIMTool.Core.Dtos.Response;
using PIMTool.Core.Interfaces.Services;

namespace PIMTool.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeResponse>> GetAll()
        {
            return Ok(await _employeeService.GetAll());
        }
    }
}
