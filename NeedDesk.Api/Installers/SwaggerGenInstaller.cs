using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace NeedDesk.Api.Installers
{
    public class SwaggerGenInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Need Desk",
                    Description = "Need Desk",
                    TermsOfService = new Uri("http://www.google.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "André Oliveira",
                        Email = "inforoliver@gmail.com",
                        Url = new Uri("http://www.google.com.br"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de licença de uso!",
                        Url = new Uri("http://www.google.com.br"),
                    }
                });

                // create button "Authorization" in the Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o Token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });
        }
    }
}
