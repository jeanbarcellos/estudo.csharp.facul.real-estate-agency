using Microsoft.Extensions.DependencyInjection;
using RealEstateAgency.Application.Service;
using RealEstateAgency.Domain.Interfaces;
using RealEstateAgency.Infra.Data.Contexts;
using RealEstateAgency.Infra.Data.Repositories;

namespace RealEstateAgency.Infra.CrossCutting.IoC
{
    public static class NativeDependencyInjector
    {
        // Application
        public static void RegisterServices(IServiceCollection services)
        {
            // Core

            // Application
            services.AddScoped<IClientAppService, ClientAppService>();
            services.AddScoped<IHouseAppService, HouseAppService>();

            // Domain

            // Infra - Data
            services.AddScoped<RealEstateAgencyContext>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();
        }
    }
}
