using Application.Multitenancy;
using Infrastructure.Identity;
using Infrastructure.Multitenancy;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Initialization;
using Infrastructure.Persistence.Seeder;
using Microsoft.EntityFrameworkCore;
using Shared.Authorization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<TenantDbContext>(m => m.UseNpgsql(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"), 
    b => b.MigrationsAssembly(typeof(TenantDbContext).Assembly.FullName)))
            .AddMultiTenant<SMPTenantInfo>()
                .WithClaimStrategy(FSHClaims.Tenant)
                .WithEFCoreStore<TenantDbContext, SMPTenantInfo>()
                .Services
            .AddScoped<ITenantService, TenantService>();

builder.Services.AddDbContext<ApplicationDbContext>(m => m.UseNpgsql(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"), 
    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

builder.Services.AddIdentity();

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)))
    .AddDbContext<ApplicationDbContext>(m => m.UseNpgsql(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"),
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)))
    .AddTransient<IDatabaseInitializer, DatabaseInitializer>()
    .AddTransient<ApplicationDbInitializer>()
    .AddTransient<ApplicationDbSeeder>();

var app = builder.Build();
await app.Services.CreateScope().ServiceProvider.GetRequiredService<IDatabaseInitializer>().InitializeDatabasesAsync(default!);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMultiTenant();

app.UseAuthorization();

app.MapControllers();

app.Run();
