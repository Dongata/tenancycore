using Models;

namespace Core.Services
{
    public interface ITenantHolder
    {
        Tenant Tenant { get; set; }
    }
}
