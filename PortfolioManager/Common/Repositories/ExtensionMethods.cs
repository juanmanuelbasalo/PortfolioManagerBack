using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Repositories
{
    public static class ExtensionMethods
    {
        public static IServiceCollection AddCustomDbContext<TContext>(this IServiceCollection services, IConfiguration configuration) where TContext : DbContext
        {
            return services.AddDbContext<TContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

    }
}
