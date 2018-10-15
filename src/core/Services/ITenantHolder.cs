using Models;

namespace Core.Services
{
	/// <summary>
	/// Class used to access tenants across a scope
	/// </summary>
    public interface ITenantHolder
    {
		/// <summary>
		/// The tenant cached in the scope
		/// </summary>
        Tenant Tenant { get; set; }
    }
}
