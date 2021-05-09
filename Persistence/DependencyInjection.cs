using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static void AddPresistance(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContextPool<ProductDbContext>(options=>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b=>b.MigrationsAssembly(typeof(ProductDbContext).Assembly.FullName)));

            services.AddScoped<IProductDbContext,ProductDbContext>();
        }
    }
}
