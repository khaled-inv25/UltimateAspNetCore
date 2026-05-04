namespace CompanyEmployees.Application.Contract.Employees
{
    public class EmployeeDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }

    }
}
