using System;
using System.Threading.Tasks;
using domainEvents.Interfaces;
using domainEvents.Repositories;
using domainEvents.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace domainEvents
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome");

            var services = ConfigureServices();

            var app = services
                        .BuildServiceProvider()
                        .GetRequiredService<App>();

            await app.Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddMediatR(typeof(Program));
            services.AddTransient<AppointmentSchedulingService>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<App>();

            return services;
        }
    }
}
