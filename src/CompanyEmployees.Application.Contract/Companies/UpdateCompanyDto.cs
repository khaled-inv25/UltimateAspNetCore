using CompanyEmployees.Application.Contract.Employees;

namespace CompanyEmployees.Application.Contract.Companies
{
    [Serializable]
    public record UpdateCompanyDto(string Name, string? Address, string? Country,
        IEnumerable<CreateEmployeeDto> Employees);
}
