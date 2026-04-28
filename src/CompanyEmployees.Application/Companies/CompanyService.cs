using CompanyEmployees.Application.Contract.Companies;
using CompanyEmployees.Application.Contract.Logger;
using CompanyEmployees.Domain;

namespace CompanyEmployees.Application.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public CompanyService(
            IRepositoryManager repositoryManager,
            ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }
    }
}
