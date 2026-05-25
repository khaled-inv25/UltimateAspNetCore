using CompanyEmployees.Domain.Shared.RequestFeatures;

namespace CompanyEmployees.Domain.Employees
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges, EmployeeParameters param);
        Task<PagedList<Employee>> GetEmployeePagedListAsync(Guid companyId, bool trackChanges, EmployeeParameters param);

        Task<Employee?> GetEmployeeById(Guid companyId, Guid id, bool trackChanges);
        Task CreateEmployeeAsync(Guid companyId, Employee employee);
        void Remove(Employee employee);
    }
}
