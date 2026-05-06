using CompanyEmployees.Application.Contract;
using CompanyEmployees.Application.Contract.Employees;
using CompanyEmployees.Domain.Shared;
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
        
        [HttpGet("{id:guid}", Name = CompanyEmployeesConsts.EmployeeRoute)]
        public async Task<IActionResult> GetEmplyeesForCompanyAsync(Guid companyId, Guid id)
        {
            return Ok(await _serviceManager.EmployeeService.GetEmployeeByIdAsync(companyId, id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeForCompanyAsync(Guid companyId, [FromBody] CreateEmployeeDto input)
        {
            var employeeDto = await _serviceManager.EmployeeService.CreateEmployeeAsync(companyId, input);

            return CreatedAtRoute(CompanyEmployeesConsts.EmployeeRoute, new { companyId, id = employeeDto.Id }, employeeDto);
        }
    }
}
