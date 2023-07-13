using Application.Multitenancy;
using Finbuckle.MultiTenant;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Initialization;
using Mapster;
using Microsoft.Extensions.Options;

namespace Infrastructure.Multitenancy;

public class TenantService : ITenantService
{
    private readonly IMultiTenantStore<SMPTenantInfo> _tenantStore;
    private readonly IDatabaseInitializer _dbInitializer;
    private readonly DatabaseSettings _dbSettings;

    public TenantService(
        IMultiTenantStore<SMPTenantInfo> tenantStore,  
        IOptions<DatabaseSettings> dbSettings)
    {
        _tenantStore = tenantStore;
        _dbSettings = dbSettings.Value;
    }

    public Task<string> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<string> CreateAsync(CreateTenantRequest request, CancellationToken cancellationToken)
    {
        if (request.ConnectionString?.Trim() == _dbSettings.ConnectionString?.Trim()) request.ConnectionString = string.Empty;

        var tenant = new SMPTenantInfo(request.Id, request.Name, request.AdminEmail, request.Issuer);
        await _tenantStore.TryAddAsync(tenant);

        try
        {
            //_dbInitializer.InitializeApplicationDbForTenantAsync(tenant, cancellationToken);
        }
        catch
        {
            await _tenantStore.TryRemoveAsync(request.Id);
            throw;
        }

        return tenant.Id;
    }

    public Task<string> DeactivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsWithIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsWithNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TenantDto>> GetAllAsync()
    {
        var tenants = (await _tenantStore.GetAllAsync()).Adapt<List<TenantDto>>();
        return tenants;
    }

    public Task<TenantDto> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateSubscription(string id, DateTime extendedExpiryDate)
    {
        throw new NotImplementedException();
    }
}
