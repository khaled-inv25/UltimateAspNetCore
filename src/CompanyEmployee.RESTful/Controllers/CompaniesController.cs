using CompanyEmployees.Application.Contract;
using CompanyEmployees.Application.Contract.Companies;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployee.RESTful.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CompaniesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            return Ok(await _serviceManager.CompanyService.GetAllCompanies(false));
        }
    }
}
