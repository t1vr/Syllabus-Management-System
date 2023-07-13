using Infrastructure.Multitenancy;

namespace Infrastructure.Persistence.Initialization;

public interface IDatabaseInitializer
{
    Task InitializeDatabasesAsync(CancellationToken cancellationToken);
    Task InitializeApplicationDbForTenantAsync(SMPTenantInfo tenant, CancellationToken cancellationToken);
}
