using Api.Domain.Services;
using Api.Handlers;
using Common.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public static class ExtensionMethods
    {
        public static IServiceCollection AddEventHandlers(this IServiceCollection services)
        {
            return services.AddScoped<IEventHandler<UserCreated>, UserCreatedHandler>();
        }
        public static IServiceCollection AddScoppedServices(this IServiceCollection services)
            => services.AddScoped<IUserService, UserService>();
    }
}
