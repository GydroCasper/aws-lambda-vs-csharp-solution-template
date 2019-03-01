using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using $safeprojectname$.Interfaces;
using $safeprojectname$.Service.Interfaces;

namespace $safeprojectname$.Code
{
    public class App : IRun
    {
        private readonly ILogger _logger;

        public App(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<string> Run(string input, ILambdaContext context)
        {
            try
            {
                return string.Empty;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return string.Empty;
            }
        }
    }
}