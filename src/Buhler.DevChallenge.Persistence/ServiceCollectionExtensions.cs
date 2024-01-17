using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Buhler.DevChallenge.Persistence.MobileFoodFacilities;

namespace Buhler.DevChallenge.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContextFactory<DevChallengeDbContext, DevChallengeDbContextFactory>();
        
        // this is necessary so db context can be used as if 'AddDbContext' was used
        services.AddScoped<DevChallengeDbContext>(sp =>
        {
            var cf = sp.GetRequiredService<IDbContextFactory<DevChallengeDbContext>>();

            return cf.CreateDbContext();
        });
        
        services.AddScoped<IMobileFoodFacilityRepository, MobileFoodFacilityRepository>();
        
        return services;
    }
}