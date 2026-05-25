using CompanyEmployees.Domain.Employees;
using CompanyEmployees.Domain.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.EntityFramework.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyEmployeeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateEmployeeAsync(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            await CreateAsync(employee);
        }

        public async Task<Employee?> GetEmployeeById(Guid companyId, Guid id, bool trackChanges)
            => await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges, EmployeeParameters param)
            => await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name)
            .Skip(param.Skip)
            .Take(param.PageSize)
            .ToListAsync();

        public async Task<PagedList<Employee>> GetEmployeePagedListAsync(Guid companyId, bool trackChanges, EmployeeParameters param)
        {
            var pagedResult = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                .OrderBy(e => e.Name)
                .Skip(param.Skip)
                .Take(param.PageSize)
                .ToListAsync();

            var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges).CountAsync();

            return PagedList<Employee>.ToPagedList(pagedResult, count, param.PageNumber, param.PageSize);
        }

        public void Remove(Employee employee) => Delete(employee);
    }
}
