using ElBastard0.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using ElBastard0.Api.Services;

namespace ElBastard0.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(
                options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
                );

            return services;
        }

        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IEntityService, EntityService>();

            return services;
        }
    }
}
