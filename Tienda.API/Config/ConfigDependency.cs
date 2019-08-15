using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using shopping.data.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Tienda.API.Config
{
    public static class ConfigDependency
    {
        public static IServiceCollection ConfigurationServiceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAutoMapper();
            services.AddSingleton(configuration);
            services.AddTransient<FacturaDataService>();
            services.AddTransient<ClienteDataService>();
            services.AddTransient<ProductoDataService>();
            services.AddTransient<FacturaDetalleDataService>();
            services.AddTransient<ProductoDataService>();


            return services;
        }

        public static IApplicationBuilder ConfigureDependency(this IApplicationBuilder app) {
            return app;
        }
    }
}
