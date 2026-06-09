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

        public const string NotValidAgeRange = "Max age can't be less than min age.";

        public const string InvalidCredentials = "Access denied invalid credentials.";
        public const string InvalidRefreshRequest = "Invalid refresh request.";
        public const string RefreshTokenIsRevoked = "Refresh token is revoked.";
        public const string RefreshTokenExpired = "Refresh token expired.";
    }
}