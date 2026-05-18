using AutoMapper;
using CompanyEmployees.Application.Contract.Companies;
using CompanyEmployees.Application.Contract.Employees;
using CompanyEmployees.Domain.Companies;
using CompanyEmployees.Domain.Employees;

namespace CompanyEmployees.Application
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<UpdateCompanyDto, Company>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>()
                .ReverseMap();
        }
    }
}
