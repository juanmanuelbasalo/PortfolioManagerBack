﻿using Common.Auth;
using Identity.Data_Access.Entities;
using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IdentityServer4
{
    public static class IdentityServerConfig
    {
        public static IIdentityServerBuilder AddCustomIdentityServer(this IServiceCollection services,
            IConfiguration configuration)
        {
            var seccion = configuration.GetSection("IdentityServer");
            var serverOptions = new IdentityServerOptions();
            seccion.Bind(serverOptions);

            var signingCredentials = CreateSigningCredentials();

            return services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.UserInteraction.LoginUrl = "/Account/Login";
                options.UserInteraction.LogoutUrl = "/Account/Logout";
            })
            //.AddConfigurationStore(options =>
            //{
            //    options.ConfigureDbContext = b => b.UseSqlServer(serverOptions.ConnectionString);
            //})
            //.AddOperationalStore(options =>
            //{
            //    options.ConfigureDbContext = b => b.UseSqlServer(serverOptions.ConnectionString);
            //})
            .AddInMemoryIdentityResources(Config.Ids)
            .AddInMemoryApiResources(Config.Apis)
            .AddInMemoryClients(Config.Clients)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddAspNetIdentity<ApplicationUser>()
            .AddSigningCredential(signingCredentials);
        }

        private static X509Certificate2 CreateSigningCredentials()
            => new X509Certificate2(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rsaCert.pfx"), "wisard80");
    }
}
