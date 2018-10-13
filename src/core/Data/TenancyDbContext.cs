using Core.Data.ModelBuilders;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Threading.Tasks;

namespace Core.Data
{
    public class TenancyDbContext : DbContext, ITenancyDbContext
    {
        public TenancyDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }

        public Task Commit() => SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddTenant();

            base.OnModelCreating(modelBuilder);
        }
    }
}
