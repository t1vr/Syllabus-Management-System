using Finbuckle.MultiTenant;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Seeder;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Initialization;

public class ApplicationDbInitializer
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ITenantInfo _currentTenant;
    private readonly ApplicationDbSeeder _dbSeeder;
    private readonly ILogger<ApplicationDbInitializer> _logger;

    public ApplicationDbInitializer(ApplicationDbContext dbContext, ITenantInfo currentTenant, ApplicationDbSeeder dbSeeder, ILogger<ApplicationDbInitializer> logger)
    {
        _dbContext = dbContext;
        _currentTenant = currentTenant;
        _dbSeeder = dbSeeder;
        _logger = logger;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        await _dbSeeder.SeedDatabaseAsync(_dbContext, cancellationToken);
    }
}

