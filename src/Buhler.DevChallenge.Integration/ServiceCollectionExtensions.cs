using Microsoft.Extensions.DependencyInjection;

namespace Buhler.DevChallenge.Integration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIntegrationServices(this IServiceCollection services)
    {
        services.AddScoped<IDataSfApiIntegrationService, DataSfApiIntegrationService>();

        return services;
    }
}