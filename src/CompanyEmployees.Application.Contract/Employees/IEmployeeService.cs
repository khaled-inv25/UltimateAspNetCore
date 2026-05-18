namespace CompanyEmployees.Application.Contract.Employees
{
    public delegate void ApplayPatchDelegate(UpdateEmployeeDto patch);

    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Guid companyId, bool trackChanges = false);
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid companyId, Guid id, bool trackChanges = false);
        Task<EmployeeDto> CreateEmployeeAsync(Guid companyId, CreateEmployeeDto input);
        Task DeleteAsync(Guid companyId, Guid id, bool trackChanges);
        Task<UpdateEmployeeDto> UpdateEmployeeAsync(Guid companyId, Guid id, UpdateEmployeeDto input);
        Task ChangeAgeAsync(Guid companyId, Guid id, ApplayPatchDelegate @delegate);
    }
}
