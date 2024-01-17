using Microsoft.Extensions.DependencyInjection;
using Buhler.DevChallenge.Application.MobileFoodFacilities;

namespace Buhler.DevChallenge.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMobileFoodFacilityService, MobileFoodFacilityService>();

        return services;
    }
}