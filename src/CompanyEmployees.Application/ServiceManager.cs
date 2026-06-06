using AutoMapper;
using CompanyEmployees.Application.Authentication;
using CompanyEmployees.Application.Companies;
using CompanyEmployees.Application.Contract;
using CompanyEmployees.Application.Contract.Authentication;
using CompanyEmployees.Application.Contract.Companies;
using CompanyEmployees.Application.Contract.Employees;
using CompanyEmployees.Application.Contract.Logger;
using CompanyEmployees.Application.Employees;
using CompanyEmployees.Domain;

namespace CompanyEmployees.Application
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IAuthenticationService> _authService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repository, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repository, logger, mapper));
            _authService = new Lazy<IAuthenticationService>(() => new AuthenticationService(repository));
        }

        public ICompanyService CompanyService => _companyService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
        public IAuthenticationService AuthService => _authService.Value;
    }
}
