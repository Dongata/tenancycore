using Core.Middlewares.TenantCatching;
using Core.Services;
using Extensions.Builders;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
		/// <summary>
		/// Adds tenancy core services into default DI
		/// </summary>
		/// <param name="services">default service collection</param>
		/// <param name="builder">Configurations for tenancy core</param>
		/// <returns></returns>
        public static IServiceCollection AddTenancyCore(this IServiceCollection services, Action<TenancyCoreServiceConfigBuilder> builder)
        {
            builder.Invoke(new TenancyCoreServiceConfigBuilder(services));

            //General settings
            services.AddScoped<ITenantHolder, TenantHolder>();
            services.AddScoped(s => new TenantCatchingList(s.GetServices<ITenantCatchingStrategy>()));

            return services;
        }
    }
}
