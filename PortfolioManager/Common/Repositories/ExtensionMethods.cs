using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Repositories
{
    /// <summary>
    /// Extension methods for anything related with Ef Core Sql Server.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Custom Service to add SqlServer dbcontext for EF Core.
        /// </summary>
        /// <typeparam name="TContext">The context we are going to use.</typeparam>
        /// <param name="services">An instance of IServiceCollection.</param>
        /// <param name="configuration">Configuration to get the connection string.</param>
        /// <returns></returns>
        public static IServiceCollection AddCustomDbContext<TContext>(this IServiceCollection services, IConfiguration configuration) where TContext : DbContext
        {
            return services.AddDbContext<TContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

    }
}
