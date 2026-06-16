using CompanyEmployees.Application.Contract;
using CompanyEmployees.Application.Contract.Authentication;
using CompanyEmployees.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace CompanyEmployee.RESTful.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IServiceManager serviceManager) 
            : base(serviceManager)
        {
        }

        [HttpPost("login")]
        [EnableRateLimiting(CompanyEmployeesConsts.AuthLimiter)]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            return Ok(await _serviceManager.AuthService.LoginAsync(model));
        }

        [HttpPost("refresh")]
        [EnableRateLimiting(CompanyEmployeesConsts.AuthLimiter)]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestDto model)
        {
            return Ok(await _serviceManager.AuthService.RefreshAsync(model));
        }
    }
}
