using Core.Data;
using Core.Middlewares.TenantCatching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Extensions.Builders
{
	/// <summary>
	/// Builder class for service collections
	/// </summary>
    public class TenancyCoreServiceConfigBuilder
    {
		#region Fields

		private readonly IServiceCollection _services;

		#endregion

		#region Constructor

		public TenancyCoreServiceConfigBuilder(IServiceCollection services)
		{
			_services = services;
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Adds ITenancyDbContext 
		/// </summary>
		/// <param name="dbcontextBuild"></param>
		/// <returns></returns>
		public TenancyCoreServiceConfigBuilder UseDbContext(Action<DbContextOptionsBuilder> dbcontextBuild)
		{
			_services.AddDbContext<ITenancyDbContext, TenancyDbContext>(dbcontextBuild);
			return this;
		}

		/// <summary>
		/// Uses a user claim tenant id catching strategy
		/// </summary>
		/// <param name="claimType">Claim type name, default is TenantId</param>
		/// <returns></returns>
		public TenancyCoreServiceConfigBuilder GetTenantIdFromClaims(string claimType = "TenantId")
		{
			_services.AddScoped<ITenantCatchingStrategy, ClaimTenantCatchingStrategy>(s => new ClaimTenantCatchingStrategy(claimType));
			return this;
		}

		/// <summary>
		/// Uses tenant id route catching strategy
		/// Routes should be defined like ".../Tenant/{id:Guid}/..."
		/// </summary>
		/// <returns></returns>
		public TenancyCoreServiceConfigBuilder GetTenantIdFromRoute()
		{
			_services.AddScoped<ITenantCatchingStrategy, RouteTenantCatchingStrategy>();
			return this;
		} 

		#endregion
	}
}
