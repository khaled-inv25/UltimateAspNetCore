using CompanyEmployees.Application.Contract;
using CompanyEmployees.Application.Contract.Authentication;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            return Ok(new
            {
                token = await _serviceManager.AuthService.LoginAsync(model)
            });
        }
    }
}
