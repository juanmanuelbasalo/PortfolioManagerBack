using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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

            var certificate = new X509Certificate2(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rsaCert.pfx"), "wisard80");
            var key = new X509SecurityKey(certificate);

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = jwtOptions.Issuer;
                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        IssuerSigningKey = key                     
                    };

                    options.Audience = jwtOptions.Audience;
                });

            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:5002")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }
    }
}
