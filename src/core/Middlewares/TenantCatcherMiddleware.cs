using Core.Data;
using Core.Middlewares.Configuration;
using Core.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Core.Middlewares
{
    public class TenantCatcherMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantCatcherMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ITenancyDbContext dbContext, ITenantHolder tenantHolder, ITenantCatchingStrategy tenantCachingStrategy)
        {
            var tenantId = tenantCachingStrategy.GetTenantId(httpContext);

            if (tenantId.HasValue)
            {
                tenantHolder.Tenant = dbContext.Tenants.Find(tenantId);
            }

            await _next(httpContext);
        }
    }
}
