using System;
using System.Threading.Tasks;
using domainEvents.Entities;
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

            // var services = ConfigureServices();

            // var app = services
            //             .BuildServiceProvider()
            //             .GetRequiredService<App>();

            // await app.Run();

            var video = new Video() { Title = "Title 1" };
            var videoEncoder = new VideoEncoderService(); //publisher
            var mailService = new MailService(); //subscriber
            var messageService = new MessageService();
            //registering the subscription
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);
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
