using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using $safeprojectname$.Interfaces;
using $safeprojectname$.Service.Helpers;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Code
{
    public class App : IRun
    {
        private readonly ILogger _logger;

        public App(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("App");
        }

        public async Task<string> Run(string input, ILambdaContext context)
        {
            try
            {
                return string.Empty;
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex, $"Body: {ex.Body}. Timestamp: {DateTime.Now: yyyy MMMM dd HH:mm: ss.fff tt zz}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Timestamp: {DateTime.Now: yyyy MMMM dd HH:mm: ss.fff tt zz}");
                throw;
            }
        }
    }
}