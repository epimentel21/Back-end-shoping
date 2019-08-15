using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.API.Config
{
    public static class ConfigSwagger
    {
        public static IServiceCollection ConfigureServiceSwagger(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                };

                c.SwaggerDoc("v1", new Info
                {
                    Title = "Demo API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Uso Bearer {token}",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);

            });
            return services;
        }

        public static IApplicationBuilder ConfigureSwagger(
            this IApplicationBuilder app,IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //if (env.IsDevelopment())
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Demo");
                //else
                //    c.SwaggerEndpoint($"{configuration["VirtualHost"]}/swagger/v1/swagger.json", "Api Demo");

                c.RoutePrefix = string.Empty;

            });
            return app;
        }
    }
}
