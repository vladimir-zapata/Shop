namespace Shop.BLL.Logger
{
    public interface ILoggerService<TService> where TService : class
    {
        void LogInformation(string message, params object[] args);
        void LogError(string message, params object[] args);
    }
}
