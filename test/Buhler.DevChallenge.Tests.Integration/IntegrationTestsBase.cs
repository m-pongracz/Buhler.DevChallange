using Microsoft.Extensions.DependencyInjection;
using Buhler.DevChallenge.WebApi.Client;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

namespace Buhler.DevChallenge.Tests.Integration;

public abstract class IntegrationTestsBase : IAssemblyFixture<TestingWebApplicationFactory>, IAsyncLifetime
{
    private readonly TestingWebApplicationFactory _factory;
    private readonly ITestOutputHelper _outputHelper;
    protected DevChallengeClient WebApiClient = null!;

    protected readonly IServiceScope Scope;
    
    protected IntegrationTestsBase(TestingWebApplicationFactory factory, ITestOutputHelper outputHelper)
    {
        _factory = factory;
        _outputHelper = outputHelper;
        Scope = factory.CreateScope();
    }
    
    protected TService GetRequiredService<TService>() where TService : notnull
    {
        return Scope.ServiceProvider.GetRequiredService<TService>();
    }

    /// <summary>
    /// Creates a WebApi client
    /// </summary>
    /// <returns>WebApi client</returns>
    protected DevChallengeClient GetWebApiClient()
    {
        var httpClient = _factory.CreateClient();

        return new DevChallengeClient(httpClient);
    }
    
    public async Task InitializeAsync()
    {
        await _factory.ResetDatabase();

        WebApiClient = GetWebApiClient();
    }
    
    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}