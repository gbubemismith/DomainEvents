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

            var services = ConfigureServices();

            var app = services
                        .BuildServiceProvider()
                        .GetRequiredService<App>();

            await app.Run();

            // using pure events
            var video = new Video() { Title = "Title 1" };

            var videoEncoder = new VideoEncoderService(); //publisher

            var mailService = new MailService(); //subscriber
            var messageService = new MessageService();//subscriber
            //registering the subscription
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);

            // Test(checkers);


            // //Testing delegates
            // DelegateService.RelaxingOnTheBeach(DrinkWater);

            // //Func -> Generic delegate
            // Func<int, int, int> add = (int a, int b) => a + b;

            // //Action -> Generic delegate, does not return a value
            // Action<int> printNumber = (n) => Console.WriteLine("Print action");
            Action<int> action = x => Console.WriteLine(x);
            Action testAction = DrinkWater;
            testAction();
            
            //Funcs
            Func<int, int> func = checkers;
            func += (x) => 12;

            Func<int, string> func1 = (x) => x.ToString();
            Func<int, bool> func2 = (x) =>
            {
                var y = x;
                return x == y;
            };
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

        public static int Test(Func<int, int> testDel)
        {

            var check = testDel(2);

            return 1;
        }

        public static int checkers(int age)
        {
            return age;
        }

        public static void DrinkWater() => Console.WriteLine("Drink water");
        public static void DrinkBeer() => Console.WriteLine("Drink beer");

    }
}
