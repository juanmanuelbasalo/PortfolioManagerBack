using Identity.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.HelperMethods
{
    public static class ExtensionMethods
    {
        public static IServiceCollection AddCustomScopedServices(this IServiceCollection services)
            => services.AddScoped<IUserService, UserService>();
    }
}
