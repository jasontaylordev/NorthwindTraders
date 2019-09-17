using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Interfaces;

namespace Northwind.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<INorthwindDbContext, NorthwindDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NorthwindDatabase")));

            return services;
        }
    }
}
