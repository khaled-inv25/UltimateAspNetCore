using CompanyEmployees.Domain.Companies;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.EntityFramework.Companies
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(CompanyEmployeeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateCompanyAsync(Company company)
            => await CreateAsync(company);

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trachChanges = false)
        {
            var query = FindAll(trachChanges).OrderBy(c => c.Name);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges = false)
            => await FindByCondition(c => ids.Contains(c.Id), trackChanges).ToListAsync();

        public async Task<Company?> GetCompanyAsync(Guid id, bool trackChanges) 
            => await FindByCondition(c => c.Id.Equals(id), trackChanges).FirstOrDefaultAsync();

        public void Remove(Company company) => Delete(company);
    }
}
