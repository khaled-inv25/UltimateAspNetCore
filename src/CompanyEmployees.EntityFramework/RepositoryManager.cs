using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Companies;
using CompanyEmployees.Domain.Employees;
using CompanyEmployees.EntityFramework.Companies;
using CompanyEmployees.EntityFramework.Employees;

namespace CompanyEmployees.EntityFramework
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly CompanyEmployeeDbContext _dbContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(CompanyEmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(dbContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
        }

        public ICompanyRepository Company => _companyRepository.Value;
        public IEmployeeRepository Employee => _employeeRepository.Value;

        public async Task Save() => await _dbContext.SaveChangesAsync();
    }
}
