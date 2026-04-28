using CompanyEmployees.Domain.Companies;

namespace CompanyEmployees.EntityFramework.Companies
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(CompanyEmployeeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
