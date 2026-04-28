using CompanyEmployees.Domain.Employees;

namespace CompanyEmployees.EntityFramework.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyEmployeeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
