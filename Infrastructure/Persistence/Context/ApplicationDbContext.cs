using Domain;
using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.EntityFrameworkCore;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.Context;

//public class ApplicationDbContext : BaseDbContext
//{
//    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options)
//        : base(currentTenant, options)
//    {
//    }

//    public DbSet<Program> Programs => Set<Program>();
//    //public DbSet<Course> Courses => Set<Course>();
//    //public DbSet<Syllabus> Syllabuses => Set<Syllabus>();
//    //public DbSet<AppUser> AppUserProfiles => Set<AppUser>();
//    //public DbSet<CourseUser> CourseUsers => Set<CourseUser>();



//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Program>().IsMultiTenant();
//        //modelBuilder.Entity<Course>().IsMultiTenant();
//        //modelBuilder.Entity<Syllabus>().IsMultiTenant();
//        //modelBuilder.Entity<AppUser>().IsMultiTenant();
//        //modelBuilder.Entity<CourseUser>().HasKey(x => new { x.CourseId, x.AppUserId });

//        base.OnModelCreating(modelBuilder);
//        modelBuilder.HasDefaultSchema(SchemaNames.Portal);
//    }
//}

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, IOptions<DatabaseSettings> dbSettings)
        : base(currentTenant, options, dbSettings)
    {
    }

    public DbSet<Program> Programs => Set<Program>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Syllabus> Syllabuses => Set<Syllabus>();
    public DbSet<AppUser> AppUserProfiles => Set<AppUser>();
    public DbSet<CourseUser> CourseUsers => Set<CourseUser>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Program>().IsMultiTenant();
        modelBuilder.Entity<Course>().IsMultiTenant();
        modelBuilder.Entity<Syllabus>().IsMultiTenant();
        modelBuilder.Entity<AppUser>().IsMultiTenant();
        modelBuilder.Entity<CourseUser>().IsMultiTenant();

        modelBuilder.Entity<CourseUser>().Ignore(x => x.Id).HasKey(x => new { x.CourseId, x.AppUserId });

        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(SchemaNames.Portal);
    }
}