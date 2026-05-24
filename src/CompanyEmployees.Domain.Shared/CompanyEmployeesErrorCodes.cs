namespace CompanyEmployees.Domain.Shared
{
    public static class CompanyEmployeesErrorCodes
    {
        public const string RequiredField = "The field is required ";
        public const string MaxLengthExceeded = "Maximum length has exceeded";
        public const string GuidsIsRequired = "Null is not allowed";

        public const string CompanyNotFound = "Company with id ({0}) not found";
        public const string CreateCompanyObjectIsNull = "CreateCompanyDto object is null";
        public const string CreateCompanyCollectionIsNull = "CreateCompanyDto objects is null";
        public const string ConpaniesMismatchFetch = "A mismatch happened when requsting companies";

        public const string EmployeeNotFound = "Employee with id ({0}) not found";

        public const string ObjectIsNull = "Object is null. Controller: {0}, Action: {1}";
    }
}