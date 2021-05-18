using Microsoft.Extensions.DependencyInjection;
using RealEstateAgency.Application.Interfaces;
using RealEstateAgency.Application.Services;
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
            services.AddScoped<IPropertyAppService, PropertyAppService>();
            services.AddScoped<IHouseAppService, HouseAppService>();
            services.AddScoped<IApartmentAppService, ApartmentAppService>();
            services.AddScoped<ILandAppService, LandAppService>();

            // Domain

            // Infra - Data
            services.AddScoped<RealEstateAgencyContext>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<ILandRepository, LandRepository>();
        }
    }
}
