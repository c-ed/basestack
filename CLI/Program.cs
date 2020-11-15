using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace SqwareBase.CLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateLogger();

                Log.Information("Starting Business CLI");

                var services = new ServiceCollection();
                Startup.Initialize(services);

                var serviceProvider = services.BuildServiceProvider();
                serviceProvider.GetRequiredService<Controller>().Operate(args);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }

        private static void CreateLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddEnvironmentVariables()
                    .Build())
                .CreateLogger();
        }
    }
}
