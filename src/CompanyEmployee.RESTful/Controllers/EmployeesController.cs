using CompanyEmployee.RESTful.RequestAttributes;
using CompanyEmployees.Application.Contract;
using CompanyEmployees.Application.Contract.Employees;
using CompanyEmployees.Domain.Shared;
using CompanyEmployees.Domain.Shared.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace CompanyEmployee.RESTful.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    [Authorize]
    public class EmployeesController : BaseController
    {
        #region ctor
        public EmployeesController(IServiceManager serviceManager) 
            : base(serviceManager) 
        {
        }
        #endregion

        #region GET

        [HttpGet]
        [SkipRequestDtoValidation]
        public async Task<IActionResult> GetEmplyeesAsync(Guid companyId, [FromQuery] EmployeeParameters param)
        {
            return Ok(await _serviceManager.EmployeeService.GetEmployeesAsync(companyId, param));
        }

        [HttpGet("paged")]
        [SkipRequestDtoValidation]
        public async Task<IActionResult> GetPagedListEmplyeesAsync(Guid companyId, [FromQuery] EmployeeParameters param)
        {
            var pagedResult = await _serviceManager.EmployeeService.GetEmployeePagedListAsync(companyId, param);

            Response.Headers.Add(CompanyEmployeesConsts.PaginationHeader,
                JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok(pagedResult);
        }

        [HttpGet("{id:guid}", Name = CompanyEmployeesConsts.EmployeeRoute)]
        public async Task<IActionResult> GetEmplyeeForCompanyAsync(Guid companyId, Guid id)
        {
            return Ok(await _serviceManager.EmployeeService.GetEmployeeByIdAsync(companyId, id));
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeForCompanyAsync(Guid companyId, [FromBody] CreateEmployeeDto input)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var employeeDto = await _serviceManager.EmployeeService.CreateEmployeeAsync(companyId, input);

            return CreatedAtRoute(CompanyEmployeesConsts.EmployeeRoute, new { companyId, id = employeeDto.Id }, employeeDto);
        }
        #endregion

        #region PUT
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, [FromBody] UpdateEmployeeDto input)
        {
            await _serviceManager.EmployeeService.UpdateEmployeeAsync(companyId, id, input);
            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployeeAsync(Guid companyId, Guid id)
        {
            await _serviceManager.EmployeeService.DeleteAsync(companyId, id, false);

            return NoContent();
        }
        #endregion

        #region PATCH
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> ChangeEmpAgeAsync(Guid companyId, Guid id, 
            [FromBody] JsonPatchDocument<UpdateEmployeeDto> jsonPatch)
        {
            await _serviceManager.EmployeeService.ChangeAgeAsync(companyId, id, jsonPatch.ApplyTo);

            return NoContent();
        }
        #endregion
    }
}
