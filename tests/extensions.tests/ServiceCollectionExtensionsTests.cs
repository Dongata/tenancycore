using Core.Middlewares.TenantCatching;
using Core.Services;
using Extensions.Tests.Fakes;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Extensions.Tests
{
	public class ServiceCollectionExtensionsTests
	{
		[Fact]
		public void AddTenancyCore_ShouldAddTenantHolderDescriptor()
		{
			var serviceDescriptors = new FakeServiceCollection();

			serviceDescriptors.AddTenancyCore(a => { });

			Assert.Contains(
				serviceDescriptors,
				s =>
					s.Lifetime == ServiceLifetime.Scoped
					&& s.ServiceType == typeof(ITenantHolder)
					&& s.ImplementationType == typeof(TenantHolder));
		}

		[Fact]
		public void AddTenancyCore_ShouldAddTenantCatchingList()
		{
			var serviceDescriptors = new FakeServiceCollection();

			serviceDescriptors.AddTenancyCore(a => { });

			Assert.Contains(
				serviceDescriptors,
				s =>
					s.Lifetime == ServiceLifetime.Scoped
					&& s.ServiceType == typeof(TenantCatchingList));
		}
	}
}
