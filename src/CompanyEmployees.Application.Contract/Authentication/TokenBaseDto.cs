namespace CompanyEmployees.Application.Contract.Authentication
{
    public record TokenBaseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
