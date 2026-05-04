namespace CompanyEmployees.Domain.Companies
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trachChanges = false);
        Task<Company?> GetCompanyAsync(Guid id, bool trackChanges);
        Task CreateCompanyAsync(Company company);
    }
}
