using Core.Middlewares;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseTenancyCore(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<TenantCatcherMiddleware>();
            return builder;
        }
    }
}
