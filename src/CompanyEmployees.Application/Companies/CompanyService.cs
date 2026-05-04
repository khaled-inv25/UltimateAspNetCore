using AutoMapper;
using CompanyEmployees.Application.Contract.Companies;
using CompanyEmployees.Application.Contract.Logger;
using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Companies;
using CompanyEmployees.Domain.Exceptions;
using CompanyEmployees.Domain.Shared;

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

        public async Task<CompanyDto> CreateCompanyAsync(CreateCompanyDto input)
        {
            var company = _mapper.Map<Company>(input);

            await _repositoryManager.Company.CreateCompanyAsync(company);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<CompanyDto>(company);
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies(bool trackChanges)
        {
            var companies =  await _repositoryManager.Company.GetAllCompaniesAsync(trackChanges);

            return _mapper.Map<IEnumerable<CompanyDto>>(companies); ;
        }

        public async Task<CompanyDto> GetCompayByIdAsync(Guid id, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(id, trackChanges);

            return company == null
                ? throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.CompanyNotFound, id))
                : _mapper.Map<CompanyDto>(company);
        }
    }
}
