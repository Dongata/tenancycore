using Models;

namespace Core.Services
{
    /// <summary>
    /// Scoped implementation that only holds a tenant
    /// Pretty much self explanatory
    /// </summary>
    public class TenantHolder : ITenantHolder
    {
        /// <summary>
        /// The tenant holded
        /// </summary>
        public Tenant Tenant { get; set; }
    }
}
