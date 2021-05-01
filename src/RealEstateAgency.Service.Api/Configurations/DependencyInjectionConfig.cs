using Microsoft.Extensions.DependencyInjection;
using RealEstateAgency.Infra.CrossCutting.IoC;
using System;

namespace RealEstateAgency.Service.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeDependencyInjector.RegisterServices(services);
        }
    }
}
