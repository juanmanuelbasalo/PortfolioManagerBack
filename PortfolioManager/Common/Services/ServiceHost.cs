using Common.Commands;
using Common.Events;
using Common.RabbitMq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    /// <summary>
    /// <c>ServiceHost</c> helps create a custom host for the apis.
    /// </summary>
    public class ServiceHost : IServiceHost
    {
        private readonly IHost host;

        /// <summary>
        /// <c>ServiceHost</c> constructor.
        /// </summary>
        /// <param name="host"> The generic host.</param>
        public ServiceHost(IHost host)
        {
            this.host = host;
        }

        /// <summary>
        /// Runs the host with a HTTP workload.
        /// This method is called at the end of the method chaining in program.
        /// </summary>
        /// <returns>Empty Task</returns>
        public async Task Run() => await host.RunAsync();

        /// <summary>
        /// Creates our own generic host using the default host builder from .net core.
        /// </summary>
        /// <typeparam name="TStartup">The startup of the microservice</typeparam>
        /// <param name="args">Console arguments</param>
        /// <returns>A <c>HostBuilder</c> instance</returns>
        public static HostBuilder CreateHostBuilder<TStartup>(string[] args) where TStartup : class
            => new HostBuilder(Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseDefaultServiceProvider(options => options.ValidateScopes = false);
                    webBuilder.UseStartup<TStartup>();
                }).Build());

        /// <summary>
        /// Abstract class to add the build capability to the method chaining.
        /// It allows us to reuse functionality.
        /// </summary>
        public abstract class BuilderBase
        {
            private readonly IHost host;
            /// <summary>
            /// <c>BuilderBase</c> ctor
            /// </summary>
            /// <param name="host"> The host we are going to build. </param>
            public BuilderBase(IHost host)
            {
                this.host = host;
            }
            /// <summary>
            /// Function to generate a new <c>ServiceHost</c> to run the web host.
            /// </summary>
            /// <returns> A new <c>ServiceHost</c></returns>
            public ServiceHost Build()
            {
                return new ServiceHost(host);
            }
        }

        /// <summary>
        /// Class to integrate Command/Event handling.
        /// </summary>
        public class BusBuilder : BuilderBase
        {
            private readonly IHost host;
            private IBusClient busClient;
            /// <summary>
            /// Constructor for the bud builder.
            /// </summary>
            /// <param name="host">The .net core host</param>
            /// <param name="busClient">The bus client that is setup in our microservices</param>
            public BusBuilder(IHost host, IBusClient busClient) : base(host)
            {
                this.busClient = busClient;
                this.host = host;
            }

            /// <summary>
            /// Method to subscribe to a command 
            /// </summary>
            /// <typeparam name="TCommand">The command to subscribe to</typeparam>
            /// <returns>To make piping possible</returns>
            public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
            {
                var handler = (ICommandHandler<TCommand>)host.Services.GetService(typeof(ICommandHandler<TCommand>));
                busClient.WithCommandHandlerAsync<TCommand>(handler);

                return this;
            }

            /// <summary>
            /// Method to subscribe to an event
            /// </summary>
            /// <typeparam name="TEvent">The event to subscribe to</typeparam>
            /// <returns>To make piping possible</returns>
            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                var handler = (IEventHandler<TEvent>)host.Services.GetService(typeof(IEventHandler<TEvent>));
                busClient.WithEventHandlerAsync<TEvent>(handler);

                return this;
            }
        }

        /// <summary>
        /// Class to integrate the RabbitMq.
        /// </summary>
        public class HostBuilder : BuilderBase
        {
            private readonly IHost host;

            /// <summary>
            /// Constructor for the HostBuilder
            /// </summary>
            /// <param name="host">Default net core host instance</param>
            public HostBuilder(IHost host) : base(host)
            {
                this.host = host;
            }

            /// <summary>
            /// Pipe for the rawrabbit implementation
            /// </summary>
            /// <returns>BusBuilder instance to construct the pipe</returns>
            public BusBuilder UseRabbitMq()
            {
                var busClient = (IBusClient)host.Services.GetService(typeof(IBusClient));
                return new BusBuilder(host, busClient);
            }
        }
    }
}
