using System;
using System.IO;
using SqwareBase.CLI.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SqwareBase.CLI
{
    public class Startup
    {
        public static void Initialize(IServiceCollection services)
        {
            var configuration = GetConfigurationBuilder();
            services.AddOptions();
            services.Configure<AppSettings>(configuration);

            ConfigureServices(services);
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Controller>();
        }

        private static IConfiguration GetConfigurationBuilder()
        {
            var environmentName = Environment.GetEnvironmentVariable("ENVIRONMENT");

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
