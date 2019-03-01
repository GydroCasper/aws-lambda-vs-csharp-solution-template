using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using $safeprojectname$.Code;
using $safeprojectname$.Dto;
using $safeprojectname$.Interfaces;
using $safeprojectname$.Service.Code;
using $safeprojectname$.Service.Helpers;
using $safeprojectname$.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace $safeprojectname$
{
    public class Function
    {
        private readonly IServiceProvider _serviceProvider;

        public Function()
        {
            _serviceProvider = BuildServiceProvider();
        }

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<APIGatewayProxyResponse> FunctionHandler(string input, ILambdaContext context)
        {
            var result = await _serviceProvider.GetService<IRun>().Run(input, context);

            return new APIGatewayProxyResponse
            {
                StatusCode = HttpStatusCode.OK,
                Body = result
            };
        }

        private static IServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IRun, App>();
            serviceCollection.AddScoped<ILogger, Logger>();

            serviceCollection.AddScoped(sp => BuildConfiguration());

            var configuration = BuildConfiguration();
            serviceCollection.AddScoped(sp => configuration);
            serviceCollection.Configure<AppSettings>(configuration);
            serviceCollection.AddOptions();

            return serviceCollection.BuildServiceProvider();
        }

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
//                .AddSystemsManager("/business-systems/okta-authentication")
                .Build();
        }
    }
}
