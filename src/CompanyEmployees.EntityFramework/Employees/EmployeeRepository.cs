using CompanyEmployees.Domain.Employees;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.EntityFramework.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyEmployeeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Employee?> GetEmployeeById(Guid companyId, Guid id, bool trackChanges)
            => await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges) 
            => await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name)
            .ToListAsync();
    }
}
