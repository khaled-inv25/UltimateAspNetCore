using CompanyEmployees.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace CompanyEmployees.Application.Contract.Authentication
{
    public record RefreshRequestDto
    {
        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        public string RefreshToken { get; set; }

        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        public Guid CompanyId { get; set; }
        
        [Required(ErrorMessage = CompanyEmployeesErrorCodes.RequiredField)]
        public string UserName { get; set; }
    }
}
