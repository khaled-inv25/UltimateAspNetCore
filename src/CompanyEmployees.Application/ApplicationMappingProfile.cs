using AutoMapper;
using CompanyEmployees.Application.Contract.Companies;
using CompanyEmployees.Domain.Companies;

namespace CompanyEmployees.Application
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Company, CompanyDto>();
        }
    }
}
