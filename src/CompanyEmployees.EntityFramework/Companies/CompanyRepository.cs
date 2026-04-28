using CompanyEmployees.Domain.Companies;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.EntityFramework.Companies
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(CompanyEmployeeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trachChanges = false)
        {
            var query = FindAll(trachChanges).OrderBy(c => c.Name);

            return await query.ToListAsync();
        }
    }
}
