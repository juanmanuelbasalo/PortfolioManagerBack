using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Auth;
using Common.Commands;
using Common.RabbitMq;
using Common.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PortfolioSystem.Data_Access.SqlServer;
using PortfolioSystem.Handlers;
using PortfolioSystem.Helpers;

namespace PortfolioSystem
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
            services.AddControllers();
            services.AddRabbitMq(Configuration);
            services.AddCustomDbContext<PortfolioSystemContext>(Configuration);
            services.AddCustomScopedServices();
            services.AddScoped(typeof(ISqlServerRepository<>), typeof(SqlServerRepository<>));
            //services.AddCustomAuthentication(Configuration);
            services.AddScoped<ICommandHandler<CreatePortfolio>, CreatePortfolioHandler>()
                    .AddScoped<ICommandHandler<BuySecurity>, BuySecuritiesHandler>();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("default");

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
