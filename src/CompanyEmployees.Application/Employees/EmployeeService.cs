using AutoMapper;
using CompanyEmployees.Application.Contract.Employees;
using CompanyEmployees.Application.Contract.Logger;
using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Employees;
using CompanyEmployees.Domain.Exceptions;
using CompanyEmployees.Domain.Shared;

namespace CompanyEmployees.Application.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(Guid companyId, CreateEmployeeDto input)
        {
            if (await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges: false) is null)
            {
                throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.CompanyNotFound, companyId));
            }

            var employee = _mapper.Map<Employee>(input);

            await _repositoryManager.Employee.CreateEmployeeAsync(companyId, employee);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid companyId, Guid id, bool trackChanges = false)
        {
            if (await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges) is null)
            {
                throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.CompanyNotFound, companyId));
            }

            var employee = await _repositoryManager.Employee.GetEmployeeById(companyId, id, trackChanges);

            if (employee is null) 
            {
                throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.EmployeeNotFound, id));
            }

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Guid companyId, bool trackChanges = false)
        {

            if (await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges) is null)
            {
                throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.CompanyNotFound, companyId));
            }

            var employees = await _repositoryManager.Employee.GetEmployeesAsync(companyId, trackChanges);

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task DeleteAsync(Guid companyId, Guid id, bool trackChanges)
        {
            if (await _repositoryManager.Company.GetCompanyAsync(companyId, false) is null)
            { 
                throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.CompanyNotFound, companyId));
            }

            var employee = await _repositoryManager.Employee.GetEmployeeById(companyId, id, false)
                ?? throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.EmployeeNotFound, id));

            _repositoryManager.Employee.Remove(employee);

            await _repositoryManager.SaveAsync();
        }

    }
}
