namespace CompanyEmployees.Application.Contract.Employees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Guid companyId, bool trackChanges = false);
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid companyId, Guid id, bool trackChanges = false);
        Task<EmployeeDto> CreateEmployeeAsync(Guid companyId, CreateEmployeeDto input);
    }
}
