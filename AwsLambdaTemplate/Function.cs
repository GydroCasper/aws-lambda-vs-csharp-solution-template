using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using $safeprojectname$.Code;
using $safeprojectname$.Dto;
using $safeprojectname$.Interfaces;
using $safeprojectname$.Service.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Serilog;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace $safeprojectname$
{
    [ExcludeFromCodeCoverage]
    public class Function
    {
        private readonly IServiceProvider _serviceProvider;

        public Function()
        {
            _serviceProvider = ConfigureServices();
        }

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<APIGatewayProxyResponse> FunctionHandler(string input, ILambdaContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var result = await scope.ServiceProvider.GetService<IRun>().Run(input, context);

                return new APIGatewayProxyResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Body = result
                };
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IRun, App>();

            serviceCollection.AddScoped(sp => BuildConfiguration());

            var configuration = BuildConfiguration();
            serviceCollection.AddScoped(sp => configuration);
            serviceCollection.Configure<AppSettings>(configuration);
            serviceCollection.AddOptions();

            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            serviceCollection.AddLogging(c => c.AddSerilog(loggerConfig));

            return serviceCollection.BuildServiceProvider();
        }

        private static IConfiguration BuildConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable("EnvironmentName");

            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                //                .AddSystemsManager("/ssm/path")
                .Build();
        }
    }
}
