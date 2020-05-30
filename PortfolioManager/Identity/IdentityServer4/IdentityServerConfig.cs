using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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

            return services.AddIdentityServer()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(serverOptions.ConnectionString);
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(serverOptions.ConnectionString);
            })
            .AddSigningCredential(signingCredentials);
        }

        private static SigningCredentials CreateSigningCredentials()
            => new SigningCredentials(new RsaSecurityKey(new RSACryptoServiceProvider(512))
                                      ,SecurityAlgorithms.RsaSha256);
    }
}
