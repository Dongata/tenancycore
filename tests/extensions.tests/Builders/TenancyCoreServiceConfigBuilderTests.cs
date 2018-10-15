using Core.Data;
using Core.Middlewares.TenantCatching;
using Extensions.Builders;
using Extensions.Tests.Fakes;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Extensions.Tests.Builders
{
	public class TenancyCoreServiceConfigBuilderTests
	{
		#region UseDbContext tests

		[Fact]
		public void UseDbContext_ShouldAddTenancyDbContextDescriptor()
		{
			var services = new FakeServiceCollection();

			var builder = new TenancyCoreServiceConfigBuilder(services);

			builder.UseDbContext(a => { });

			Assert.Contains(
				services,
				s => s.Lifetime == ServiceLifetime.Scoped
				&& s.ImplementationType == typeof(TenancyDbContext)
				&& s.ServiceType == typeof(ITenancyDbContext));
		}

		#endregion

		#region GetTenantIdFromClaims tests

		[Fact]
		public void GetTenantIdFromClaims_ShouldAddAClaimTenantCatchingStrategy() =>
			TestCatchingStrategyAddition(
				a => a.GetTenantIdFromClaims(),
				typeof(ClaimTenantCatchingStrategy));

		#endregion

		#region GetTenantIdFromRoute tests

		[Fact]
		public void GetTenantIdFromRoute_ShouldAddARouteTenantCatchingStrategy() =>
			TestCatchingStrategyAddition(
				a => a.GetTenantIdFromRoute(), 
				typeof(RouteTenantCatchingStrategy));

		#endregion

		#region Private methods

		private void TestCatchingStrategyAddition(Action<TenancyCoreServiceConfigBuilder> call, Type implementationType)
		{
			var services = new FakeServiceCollection();

			var builder = new TenancyCoreServiceConfigBuilder(services);

			call.Invoke(builder);

			Assert.Contains(
				services,
				s => s.Lifetime == ServiceLifetime.Scoped
				&& s.ImplementationType == implementationType
				&& s.ServiceType == typeof(ITenantCatchingStrategy));
		}

		#endregion
	}
}
