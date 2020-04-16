using Common.Commands;
using Common.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Instantiation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.RabbitMq
{
    /// <summary>
    /// <c>ExtensionMethods</c> acts as a helper class for any raw rabbit implementations.
    /// </summary>
    public static class ExtensionMethods
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient busClient,
            ICommandHandler<TCommand> commandHandler) where TCommand : ICommand
        => busClient.SubscribeAsync<TCommand>(async msg => await commandHandler.HandleAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg => cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));
        public static Task WithEventHandlerAsync<TEvent>(this IBusClient busClient,
            IEventHandler<TEvent> commandHandler) where TEvent : IEvent
        => busClient.SubscribeAsync<TEvent>(async msg => await commandHandler.HandleAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg => cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));
        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

        /// <summary>
        /// Method to add a custom raw rabbit implementation with options from my appsettings.
        /// </summary>
        /// <param name="services"> Add as a singleton service.</param>
        /// <param name="configuration"> Get the RabbitMq section.</param>
        /// <returns> IServiceCollection to follow with the pipeline.</returns>
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitSection = configuration.GetSection("RabbitMq");
            var rabbitOptions = new RawRabbitConfiguration();
            rabbitSection.Bind(rabbitOptions);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = rabbitOptions
            });
            return services.AddSingleton<IBusClient>(client);
        }
    }
}
