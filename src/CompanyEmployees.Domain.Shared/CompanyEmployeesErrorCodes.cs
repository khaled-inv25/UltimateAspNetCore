namespace CompanyEmployees.Domain.Shared
{
    public static class CompanyEmployeesErrorCodes
    {
        public const string RequiredField = "The field is required ";
        public const string MaxLengthExceeded = "Maximum length has exceeded";

        public const string CompanyNotFound = "Company with id ({0}) not found";
        public const string CreateCompanyObjectIsNull = "CreateCompanyDto object is null";

        public const string EmployeeNotFound = "Employee with id ({0}) not found";
    }
}