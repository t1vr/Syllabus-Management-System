using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistence.Seeder;

public static class DatabaseManager
{
    public static async void SeedData(this IServiceCollection services, IHost app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var dbSeeder = serviceProvider.GetRequiredService<ApplicationDbSeeder>();
            //await dbSeeder.SeedDatabaseAsync();
        }
    }
}