using Microsoft.Extensions.DependencyInjection;

namespace Buhler.DevChallenge.Persistence.Migrations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMigrator(this IServiceCollection services)
    {
        return services.AddScoped<IMigrationService, MigrationService>();
    }
}