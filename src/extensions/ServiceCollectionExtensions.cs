using Core.Data;
using Core.Middlewares.Configuration;
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
            services.AddDbContext<ITenancyDbContext, TenancyDbContext>(dbcontextBuild);

            return services;
        }
    }
}
