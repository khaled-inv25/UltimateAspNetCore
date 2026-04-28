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

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges)
        {
            var companies =  await _repositoryManager.Company.GetAllCompaniesAsync(trackChanges);

            List<CompanyDto> dtos = new();

            foreach (var company in companies)
            {
                dtos.Add(new CompanyDto
                {
                    Id = company.Id,
                    Name = company.Name,
                    Address = company.Address,
                    Country = company.Country,
                });
            }

            return dtos;
        }
    }
}
