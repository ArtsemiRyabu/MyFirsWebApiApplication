using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI1.Application.Interfaces;
using WebAPI1.Persistence.Data;

namespace WebAPI1.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connStr = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(connStr);
            });
            services.AddScoped<IContext>(provider =>
                provider.GetService<Context>());
            return services;
        }
    }
}
