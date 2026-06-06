using CompanyEmployees.Domain.Shared;
using CompanyEmployees.Domain.Shared.Employees;
using System.ComponentModel.DataAnnotations;

namespace CompanyEmployees.Application.Contract.Authentication
{
    public record LoginDto
    {
        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        [MaxLength(EmployeeConsts.MaxUserNameLength, ErrorMessage = CompanyEmployeesErrorCodes.MaxLengthExceeded)]
        public string UserName { get; set; }

        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        public string Password { get; set; }
    }
}
