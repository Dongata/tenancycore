using Microsoft.EntityFrameworkCore;
using Models;

namespace Core.Data.ModelBuilders
{
    public static class TenantModelBuilder
    {
        public static ModelBuilder AddTenant(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>()
                .HasKey(a => a.Id);

            return modelBuilder;
        }
    }
}
