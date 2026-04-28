using CompanyEmployees.Application.Contract.Companies;
using CompanyEmployees.Application.Contract.Employees;

namespace CompanyEmployees.Application.Contract
{
    public interface IServiceManager
    {
        public ICompanyService CompanyService { get; }
        public IEmployeeService EmployeeService { get; }

    }
}
