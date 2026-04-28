namespace CompanyEmployees.Application.Contract.Companies
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges);
    }
}
