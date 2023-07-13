using Application.Common.Interfaces;
using Domain;
using Finbuckle.MultiTenant;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace Infrastructure.Persistence.Context;

//public class BaseDbContext : MultiTenantIdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, ApplicationRoleClaim, IdentityUserToken<string>>
//{
//    protected readonly ICurrentUser _currentUser;

//    public BaseDbContext(ITenantInfo currentTenant, DbContextOptions options)
//   : base(currentTenant, options)
//    {
//    }



//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        // QueryFilters need to be applied before base.OnModelCreating

//        base.OnModelCreating(modelBuilder);

//        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
//    }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {

//    }

//    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
//    {
//        HandleAuditingBeforeSaveChanges(Guid.Parse("d46e9f80-f29b-4eb2-9345-06f69e96d5f0"));

//        int result = await base.SaveChangesAsync(cancellationToken);


//        return result;
//    }

//    private void HandleAuditingBeforeSaveChanges(Guid userId)
//    {
//        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
//        {
//            switch (entry.State)
//            {
//                case EntityState.Added:
//                    entry.Entity.CreatedBy = userId;
//                    entry.Entity.LastModifiedBy = userId;
//                    break;

//                case EntityState.Modified:
//                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
//                    entry.Entity.LastModifiedBy = userId;
//                    break;
//            }
//        }

//        ChangeTracker.DetectChanges();
//    }
//}


public class BaseDbContext : MultiTenantIdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, ApplicationRoleClaim, IdentityUserToken<string>>
{
    protected readonly ICurrentUser _currentUser;
    private readonly DatabaseSettings _dbSettings;

    public BaseDbContext(ITenantInfo currentTenant, DbContextOptions options, IOptions<DatabaseSettings> dbSettings)
   : base(currentTenant, options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        HandleAuditingBeforeSaveChanges(Guid.Parse("d46e9f80-f29b-4eb2-9345-06f69e96d5f0"));

        int result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    private void HandleAuditingBeforeSaveChanges(Guid userId)
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = userId;
                    entry.Entity.LastModifiedBy = userId;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = userId;
                    break;

            }
        }

        ChangeTracker.DetectChanges();

    }
}