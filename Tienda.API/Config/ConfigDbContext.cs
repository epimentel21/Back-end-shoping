using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using shopping.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Tienda.API.Config
{
    public static class ConfigDbContext
    {
        public static IServiceCollection ConfigurationServicesDbContext(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ShoppingContext>(option => {
                option.UseSqlServer(configuration.GetConnectionString("default"), o => {
                    o.MigrationsAssembly(typeof(ShoppingContext).Assembly.FullName);
                 });
            });

            return services;
        }
    }
}
