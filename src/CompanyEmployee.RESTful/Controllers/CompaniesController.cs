using CompanyEmployees.Application.Contract;
using CompanyEmployees.Application.Contract.Companies;
using CompanyEmployees.Domain.Shared;
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

        [HttpGet("{id:guid}", Name = CompanyEmployeesConsts.CompanyRoute)]
        public async Task<IActionResult> GetCompanyByIdAsync(Guid id)
        {
            return Ok(await _serviceManager.CompanyService.GetCompayByIdAsync(id, trackChanges: false));
        }

        [HttpGet("collection/({ids})", Name = CompanyEmployeesConsts.CompanyCollectionRoute)]
        public async Task<IActionResult> GetByIds(IEnumerable<Guid> ids)
        {
            return Ok(await _serviceManager.CompanyService.GetByIdsAsync(ids, trackChanges: false));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyAsync([FromBody] CreateCompanyDto input)
        {
            if (input is null)
            {
                return BadRequest(CompanyEmployeesErrorCodes.CreateCompanyObjectIsNull);
            }

            var createdCompany = await _serviceManager.CompanyService.CreateCompanyAsync(input);

            return CreatedAtRoute(CompanyEmployeesConsts.CompanyRoute, new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCollection([FromBody] IEnumerable<CreateCompanyDto> input)
        {
            var (companies, ids) = await _serviceManager.CompanyService.CreateCompanyCollectionAsync(input);

            return CreatedAtRoute(CompanyEmployeesConsts.CompanyCollectionRoute, new { ids }, companies);
        }
    }
}
