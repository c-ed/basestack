using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SqwareBase.Business;
using SqwareBase.Business.Config;

namespace SqwareBase.Engine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateLogger();

                Log.Information("test");

                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    services.GetRequiredService<BusinessService>().Start();
                }

                host.Run();
            }
            catch (Exception exception)
            {
                Log.Error($"Error: {exception}");
            }

            Log.CloseAndFlush();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.UseStartup<Startup>();
                });

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
