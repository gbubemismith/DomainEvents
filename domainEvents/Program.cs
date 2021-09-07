using System;
using Microsoft.Extensions.DependencyInjection;

namespace domainEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
        }

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();


            return services;
        }
    }
}
