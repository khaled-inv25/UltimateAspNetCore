namespace CompanyEmployees.Domain.Companies
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trachChanges = false);
    }
}
