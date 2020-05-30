using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Common.Auth
{
    public static class Extensions
    {
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = new JwtOptions();
            var seccion = configuration.GetSection("jwt");
            seccion.Bind(jwtOptions);

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = jwtOptions.Issuer;
                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        IssuerSigningKey = new RsaSecurityKey(new RSACryptoServiceProvider(512)),
                    };

                    options.Audience = "api1";
                });
        }
    }
}
