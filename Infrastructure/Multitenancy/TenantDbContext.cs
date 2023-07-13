using Finbuckle.MultiTenant.Stores;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Multitenancy;

public class TenantDbContext : EFCoreStoreDbContext<SMPTenantInfo>
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SMPTenantInfo>().ToTable("Tenants", SchemaNames.MultiTenancy);
    }
}