using CompanyEmployee.RESTful.ModelBinders;
using CompanyEmployees.Application.Contract;
using CompanyEmployees.Application.Contract.Companies;
using CompanyEmployees.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployee.RESTful.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : BaseController
    {
        #region ctor
        public CompaniesController(IServiceManager serviceManager)
            : base(serviceManager)
        {
        }
        #endregion

        #region GET
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
        public async Task<IActionResult> GetByIdsAsync([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            return Ok(await _serviceManager.CompanyService.GetByIdsAsync(ids, trackChanges: false));
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> CreateCompanyAsync([FromBody] CreateCompanyDto input)
        {
            var createdCompany = await _serviceManager.CompanyService.CreateCompanyAsync(input);

            return CreatedAtRoute(CompanyEmployeesConsts.CompanyRoute, new { id = createdCompany.Id }, createdCompany);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCollectionAsync([FromBody] IEnumerable<CreateCompanyDto> input)
        {
            var (companies, ids) = await _serviceManager.CompanyService.CreateCompanyCollectionAsync(input);

            return CreatedAtRoute(CompanyEmployeesConsts.CompanyCollectionRoute, new { ids }, companies);
        }
        #endregion

        #region PUT
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCompanyAsync(Guid id, [FromBody] UpdateCompanyDto input)
        {
            await _serviceManager.CompanyService.UpdateCompanyAsync(id, input, trackChanges: true);
            return NoContent();
        }
        #endregion

        #region DELETE
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompanyAsync(Guid id)
        {
            await _serviceManager.CompanyService.DeleteAsync(id, false);

            return NoContent();
        }
        #endregion
    }
}
