namespace CompanyEmployees.Application.Contract.Logger
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogDebug(string message);
        void LogWarning(string message);
        void LogError(string message);
            
    }
}
