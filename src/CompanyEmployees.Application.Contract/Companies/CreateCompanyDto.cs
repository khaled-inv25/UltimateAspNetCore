namespace CompanyEmployees.Application.Contract.Companies
{
    public record CreateCompanyDto(string Name, string? Address, string? Country);
}
