using Microsoft.Extensions.Logging;

namespace Shop.BLL.Logger
{
    public class LoggerService<TService> : ILoggerService<TService> where TService : class
    {
        private readonly ILogger<TService> logger;

        public LoggerService(ILogger<TService> logger)
        {
            this.logger = logger;
        }
        public void LogError(string message, params object[] args)
        {
            // completar //
            this.logger.LogError(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            // completar //
            this.logger.LogInformation(message, args);

        }
    }
}
