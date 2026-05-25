using AutoMapper;
using CompanyEmployees.Application.Contract.Employees;
using CompanyEmployees.Application.Contract.Logger;
using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Employees;
using CompanyEmployees.Domain.Exceptions;
using CompanyEmployees.Domain.Shared;
using CompanyEmployees.Domain.Shared.RequestFeatures;

namespace CompanyEmployees.Application.Employees
{
    public class EmployeeService : IEmployeeService
    {
        #region fielsa
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public EmployeeService(
            IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion

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
            await CheckCompanyExistence(companyId, trackChanges);

            var employee = await _repositoryManager.Employee.GetEmployeeById(companyId, id, trackChanges);

            if (employee is null) 
            {
                throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.EmployeeNotFound, id));
            }

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Guid companyId, EmployeeParameters param, bool trackChanges = false)
        {
            await CheckCompanyExistence(companyId, trackChanges);

            var employees = await _repositoryManager.Employee.GetEmployeesAsync(companyId, trackChanges, param);

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<PagedList<EmployeeDto>> GetEmployeePagedListAsync(Guid companyId, EmployeeParameters param, bool trackChanges = false)
        {
            await CheckCompanyExistence(companyId, trackChanges);

            var employeePagedList = await _repositoryManager.Employee.GetEmployeePagedListAsync(companyId, trackChanges, param);

            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employeePagedList.ToList());

            var pagedListDto = PagedList<EmployeeDto>
                .ToPagedList(employeeDtos, employeePagedList.MetaData.TotalCount, param.PageNumber, param.PageSize);

            return pagedListDto;
        }

        public async Task<UpdateEmployeeDto> UpdateEmployeeAsync(Guid companyId, Guid id, UpdateEmployeeDto input)
        {
            if (await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges: false) is null)
            {
                throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.CompanyNotFound, companyId));
            }

            var employee = await _repositoryManager.Employee.GetEmployeeById(companyId, id, trackChanges: true)
                ?? throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.EmployeeNotFound, id));

            _mapper.Map(input, employee);
            await _repositoryManager.SaveAsync();

            return input;
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

        public async Task ChangeAgeAsync(Guid companyId, Guid id, ApplayPatchDelegate @delegate)
        {
            if (await _repositoryManager.Company.GetCompanyAsync(companyId, false) is null)
            {
                throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.CompanyNotFound, companyId));
            }

            var employee = await _repositoryManager.Employee.GetEmployeeById(companyId, id, true)
                ?? throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.EmployeeNotFound, id));

            var empToPatch = _mapper.Map<UpdateEmployeeDto>(employee);

            @delegate(empToPatch);

            _mapper.Map(empToPatch, employee);

            await _repositoryManager.SaveAsync();
        }

        #region helpers
        public async Task CheckCompanyExistence(Guid id, bool trackChanges)
        {
            if (await _repositoryManager.Company.GetCompanyAsync(id, trackChanges) is null)
            {
                throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.CompanyNotFound, id));
            }

        }
        #endregion
    }
}
