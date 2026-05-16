namespace CompanyEmployees.Application.Contract.Companies
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges);
        Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges = false);
        Task<CompanyDto> GetCompayByIdAsync(Guid id, bool trackChanges);
        Task<CompanyDto> CreateCompanyAsync(CreateCompanyDto input);
        Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CreateCompanyDto> input);
        Task UpdateCompanyAsync(Guid id, UpdateCompanyDto input, bool trackChanges);
        Task DeleteAsync(Guid id, bool trackChanges);
    }
}
