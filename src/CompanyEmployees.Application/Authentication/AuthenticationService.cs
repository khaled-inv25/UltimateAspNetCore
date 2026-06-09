using CompanyEmployees.Application.Contract.Authentication;
using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Employees;
using CompanyEmployees.Domain.Exceptions;
using CompanyEmployees.Domain.Shared;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CompanyEmployees.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AuthenticationService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<string> LoginAsync(LoginDto input)
        {
            await CheckCompanyExistence(input.CompanyId, trackChanges: false);

            var user = await _repositoryManager.Employee.GetEmployeeByUserNameAsync(input.CompanyId, input.UserName, trackChanges: false);

            if (user is null)
            {
                throw new UnauthorizedException(CompanyEmployeesErrorCodes.InvalidCredentials);
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(input.Password, user.Password);

            if (!isValidPassword)
            {
                throw new UnauthorizedException(CompanyEmployeesErrorCodes.InvalidCredentials);
            }

            return GenerateToken(user);
        }
       
        #region Token
        private string GenerateToken(Employee user)
        {
            var claims = GenerateClaims(user);
            var key = GenerateKey();
            var creds = GenerateSignature(key);

            var token = new JwtSecurityToken(
               issuer: "CompanyImployeeApi",
               audience: "CompanyImployeeApiUsers",
               claims: claims,
               expires: DateTime.Now.AddMinutes(30),
               signingCredentials: creds
           );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Claim[] GenerateClaims(Employee user)
        {
            return
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
            ];
        }

        private SymmetricSecurityKey GenerateKey()
        {
#if DEBUG
            return new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456"));
#else
return new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456"));
#endif
        }

        public SigningCredentials GenerateSignature(SymmetricSecurityKey key)
        {
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }
        #endregion

        #region helpers
        private async Task CheckCompanyExistence(Guid id, bool trackChanges)
        {
            if (await _repositoryManager.Company.GetCompanyAsync(id, trackChanges) is null)
            {
                throw new NotFoundException(string.Format(CompanyEmployeesErrorCodes.CompanyNotFound, id));
            }

        }
        #endregion
    }
}
