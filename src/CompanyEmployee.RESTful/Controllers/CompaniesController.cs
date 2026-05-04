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

        [HttpGet("{id:guid}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompanyByIdAsync(Guid id)
        {
            return Ok(await _serviceManager.CompanyService.GetCompayByIdAsync(id, trackChanges: false));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyAsync(CreateCompanyDto companyDto)
        {
            if ( companyDto is null)
            {
                return BadRequest("CompanyForCreationDto object is null");
            }

            var createdCompany = await _serviceManager.CompanyService.CreateCompanyAsync(companyDto);

            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
         }
    }
}
