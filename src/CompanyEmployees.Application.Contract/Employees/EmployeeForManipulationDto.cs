using CompanyEmployees.Domain.Shared;
using CompanyEmployees.Domain.Shared.Employees;
using System.ComponentModel.DataAnnotations;

namespace CompanyEmployees.Application.Contract.Employees
{
    public abstract record EmployeeForManipulationDto
    {
        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        [MaxLength(EmployeeConsts.MaxNameLength, ErrorMessage = CompanyEmployeesErrorCodes.MaxLengthExceeded)]
        public string Name { get; init; }
        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        public int Age { get; init; }
        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        [MaxLength(EmployeeConsts.MaxPositionLength, ErrorMessage = CompanyEmployeesErrorCodes.MaxLengthExceeded)]
        public string Position { get; init; }
    }
}
