using CompanyEmployees.Domain.Companies;
using CompanyEmployees.Domain.Shared;
using CompanyEmployees.Domain.Shared.Employees;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployees.Domain.Employees
{
    public class Employee : BaseEntity<Guid>
    {
        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        [MaxLength(EmployeeConsts.MaxNameLength, ErrorMessage = CompanyEmployeesErrorCodes.MaxLengthExceeded)]
        public string Name { get; set; }

        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        public int Age { get; set; }

        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        [MaxLength(EmployeeConsts.MaxPositionLength, ErrorMessage = CompanyEmployeesErrorCodes.MaxLengthExceeded)]
        public string? Position { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
