using Buhler.DevChallenge.Domain.Settings;
using Buhler.DevChallenge.Persistence;
using Buhler.DevChallenge.Tests.Integration.Docker;
using Buhler.DevChallenge.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Buhler.DevChallenge.Tests.Integration;

// ReSharper disable once ClassNeverInstantiated.Global
public class TestingWebApplicationFactory : WebApplicationFactory<Startup>, IAsyncLifetime
{
    private readonly TestContainers _testContainers = new();
    private RespawnerService? _respawnerService;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(SetupServices);
    }

    public IServiceScope CreateScope()
    {
        return base.Services.CreateScope();
    }

    private void SetupServices(IServiceCollection services)
    {
        var dbContextFactoryDesc =
            services.Single(d => d.ServiceType == typeof(IDbContextFactory<DevChallengeDbContext>));
        services.Remove(dbContextFactoryDesc);

        services.AddSingleton<IDbContextFactory<DevChallengeDbContext>>(_ => new DevChallengeDbContextFactory(
            new OptionsWrapper<DbConnectionSettings>(new DbConnectionSettings()
            {
                UseInMemoryDatabase = false,
                ConnectionString = _testContainers.GetDbConnectionString()
            })));
    }

    public async Task ResetDatabase()
    {
        await _respawnerService!.RunRespawner();

        using var scope = Server.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<DevChallengeDbContext>();
        dbContext.ChangeTracker.Clear();
    }

    public virtual async Task InitializeAsync()
    {
        await _testContainers.InitializeAsync();

        using var scope = Server.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DevChallengeDbContext>();
        await dbContext.Database.MigrateAsync();

        // must be instantiated after containers are running so cnnString can be retrieved from the test container
        _respawnerService = new RespawnerService(_testContainers);
        await _respawnerService.InitAsync();
    }

    public new async Task DisposeAsync()
    {
        await _testContainers.DisposeAsync();
        await base.DisposeAsync();
    }
}