using CompanyEmployees.Application.Contract;
using Microsoft.AspNetCore.Mvc;


namespace CompanyEmployee.RESTful.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public EmployeesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmplyeesAsync(Guid companyId)
        {
            return Ok(await _serviceManager.EmployeeService.GetEmployeesAsync(companyId));
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEmplyeesForCompanyAsync(Guid companyId, Guid id)
        {
            return Ok(await _serviceManager.EmployeeService.GetEmployeeByIdAsync(companyId, id));
        }
    }
}
