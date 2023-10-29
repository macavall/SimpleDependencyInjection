using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjectionExample
{
    public interface IService
    {
        void Serve();
    }

    public class Service : IService
    {
        public void Serve()
        {
            Console.WriteLine("Service Called");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create service collection
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            // Create service provider
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            // Get service from DI and use it
            IService service = serviceProvider.GetService<IService>();
            service.Serve();

            Console.ReadLine();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IService, Service>();
        }
    }
}
