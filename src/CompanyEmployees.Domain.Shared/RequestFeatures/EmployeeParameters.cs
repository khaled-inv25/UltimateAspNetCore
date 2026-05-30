namespace CompanyEmployees.Domain.Shared.RequestFeatures
{
    public class EmployeeParameters : RequestParameters
    {
        public uint MinAge { get; set; }
        public uint MaxAge { get; set; } = uint.MaxValue;

        public bool IsValideAge => MaxAge > MinAge;

        public string? SearchTerm { get; set; }

        public EmployeeParameters()
        {
            OrderBy = "name";
        }
    }
}
