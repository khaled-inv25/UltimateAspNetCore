namespace CompanyEmployees.Domain.Employees
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges);

        Task<Employee?> GetEmployeeById(Guid companyId, Guid id, bool trackChanges);
    }
}
