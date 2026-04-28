using CompanyEmployees.Domain.Employees;
using CompanyEmployees.Domain.Shared;
using CompanyEmployees.Domain.Shared.Companies;
using System.ComponentModel.DataAnnotations;

namespace CompanyEmployees.Domain.Companies
{
    public class Company : BaseEntity<Guid>
    {
        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        [MaxLength(CompanyConsts.MaxNameLength, ErrorMessage = CompanyEmployeesErrorCodes.MaxLengthExceeded)]
        public string Name { get; set; }

        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        [MaxLength(CompanyConsts.MaxAddressLength, ErrorMessage = CompanyEmployeesErrorCodes.MaxLengthExceeded)]
        public string? Address { get; set; }

        public string? Country { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
