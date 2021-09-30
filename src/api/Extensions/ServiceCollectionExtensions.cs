using ElBastard0.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using ElBastard0.Api.Services;

namespace ElBastard0.Api.Extensions
{
    /// <summary>
    /// Extensions for IServiceCollection used by dependency injection
    /// </summary>
    internal static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add database context from configuration connection string
        /// </summary>
        /// <param name="services">Application service collection</param>
        /// <param name="configuration">Application configuration</param>
        /// <returns>updated application service collection</returns>
        public static IServiceCollection AddSqlServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Sqlite context provider for demo purposes use e.g. SQL Server for production use
            services.AddDbContext<MyDbContext>(
                options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
                );

            return services;
        }

        /// <summary>
        /// Add services for repository pattern data access
        /// </summary>
        /// <param name="services">Application service collection</param>
        /// <returns>updated application service collection</returns>
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            // Example entity service generic implementation
            services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));

            return services;
        }
    }
}
