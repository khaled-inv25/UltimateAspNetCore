using CompanyEmployees.Domain.Companies;
using CompanyEmployees.Domain.Employees;

namespace CompanyEmployees.Domain
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee {  get; }
        Task Save();
    }
}
