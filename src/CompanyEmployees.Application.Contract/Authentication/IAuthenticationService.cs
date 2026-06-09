namespace CompanyEmployees.Application.Contract.Authentication
{
    public interface IAuthenticationService
    {
        Task<TokenResponseDto> LoginAsync(LoginDto input);
        Task<TokenResponseDto?> RefreshAsync(RefreshRequestDto input);
    }
}
