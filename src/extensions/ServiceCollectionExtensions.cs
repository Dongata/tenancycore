using Core.Data;
using Core.Middlewares.TenantCatching;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTenancyCore(this IServiceCollection services, Action<DbContextOptionsBuilder> dbcontextBuild)
        {
            services.AddScoped<ITenantHolder, TenantHolder>();
            services.AddScoped<ITenantCatchingStrategy, RouteTenantCatchingStrategy>();
            services.AddScoped<ITenantCatchingStrategy, ClaimTenantCatchingStrategy>();
            services.AddScoped<TenantCatchingList>(s=> new TenantCatchingList(s.GetServices<ITenantCatchingStrategy>()));
            services.AddDbContext<ITenancyDbContext, TenancyDbContext>(dbcontextBuild);

            return services;
        }
    }
}
