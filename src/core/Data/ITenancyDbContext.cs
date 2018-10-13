using Microsoft.EntityFrameworkCore;
using Models;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface ITenancyDbContext
    {
        DbSet<Tenant> Tenants { get; }

        Task Commit();
    }
}
