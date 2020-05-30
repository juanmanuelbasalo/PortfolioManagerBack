using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Auth;
using Common.Commands;
using Common.RabbitMq;
using Common.Repositories;
using Identity.Data_Access.SqlServer;
using Identity.Handlers;
using Identity.HelperMethods;
using Identity.IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddLogging();
            services.AddCustomDbContext<IdentityContext>(Configuration);
            services.AddScoped(typeof(ISqlServerRepository<>),typeof(SqlServerRepository<>));
            services.AddScoped<ICommandHandler<CreateUser>, CreateUserHandler>();
            services.AddRabbitMq(Configuration);
            services.AddAutoMapper(typeof(Startup));
            services.AddCustomScopedServices();
            services.AddCustomIdentityServer(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
   
        }

    }
}
