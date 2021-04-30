using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateAgency.Infra.Data.Contexts;
using System;

namespace RealEstateAgency.Service.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<RealEstateAgencyContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default")));
        }
    }
}
