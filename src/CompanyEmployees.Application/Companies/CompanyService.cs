using AutoMapper;
using CompanyEmployees.Application.Contract.Companies;
using CompanyEmployees.Application.Contract.Logger;
using CompanyEmployees.Domain;

namespace CompanyEmployees.Application.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CompanyService(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges)
        {
            var companies =  await _repositoryManager.Company.GetAllCompaniesAsync(trackChanges);

            return _mapper.Map<IEnumerable<CompanyDto>>(companies); ;
        }
    }
}
