namespace CompanyEmployees.Application.Contract.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(LoginDto input);
    }
}
