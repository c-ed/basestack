using System;
using Microsoft.Extensions.DependencyInjection;

namespace SqwareBase.CLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
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
    }
}
