using CompanyEmployees.Application.Contract.Employees;
using CompanyEmployees.Application.Contract.Logger;
using CompanyEmployees.Domain;

namespace CompanyEmployees.Application.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public EmployeeService(
            IRepositoryManager repositoryManager, 
            ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }
    }
}
