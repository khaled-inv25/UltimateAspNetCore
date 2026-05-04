namespace CompanyEmployees.Application.Contract.Companies
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges);
        Task<CompanyDto> GetCompayByIdAsync(Guid id, bool trackChanges);
        Task<CompanyDto> CreateCompanyAsync(CreateCompanyDto input);
    }
}
