using System.Threading.Tasks;
using Common.Commands;
using Common.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Identity
{
    /// <summary>
    /// Class for the Microservice entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point for the <c>Identity</c> Microservice.
        /// </summary>
        /// <remarks>
        /// It builds a generic host for upcoming requests from other microservices.
        /// It builds like a pipeline, adding first rabbitmq, subscribes to the command, builds and run the web host.
        /// </remarks>
        /// <param name="args">Arguments to pass to the microservice.</param>
        /// <returns></returns>
        public static async Task Main(string[] args)
        {
            await ServiceHost.CreateHostBuilder<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<CreateUser>()
                .Build()
                .Run();
        }

    }
}
