using Buhler.DevChallenge.Domain.Settings;

namespace Buhler.DevChallenge.WebApi;

internal static class WebApiServiceCollectionExtensions
{
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbConnectionSettings>(configuration.GetSection(DbConnectionSettings.SectionName));
        
        return services;
    }
}