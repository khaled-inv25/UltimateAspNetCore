namespace CompanyEmployees.Application.Contract.Companies
{
    public class CompanyDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }

    }
}
