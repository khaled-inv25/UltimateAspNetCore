namespace CompanyEmployees.Application.Contract.Companies
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges);
        Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges = false);
        Task<CompanyDto> GetCompayByIdAsync(Guid id, bool trackChanges);
        Task<CompanyDto> CreateCompanyAsync(CreateCompanyDto input);
    }
}
