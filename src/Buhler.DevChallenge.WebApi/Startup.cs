using System.Text.Json.Serialization;
using Buhler.DevChallenge.Application;
using Buhler.DevChallenge.Application.MobileFoodFacilities;
using Buhler.DevChallenge.Integration;
using Buhler.DevChallenge.Persistence;
using Buhler.DevChallenge.Persistence.Migrations;

namespace Buhler.DevChallenge.WebApi;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(x =>
        {
            x.IncludeXmlComments("Buhler.DevChallenge.WebApi.xml");
        });
        
        services
            .AddSettings(_configuration)
            .AddPersistence()
            .AddIntegrationServices()
            .AddMigrator()
            .AddApplicationServices();
    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        OnStartAsync(app.ApplicationServices).ConfigureAwait(false).GetAwaiter().GetResult();
    }

    private static async Task OnStartAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        
        var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationService>();

        await migrationService.MigrateAsync();
        
        var mobileFoodFacilityService = scope.ServiceProvider.GetRequiredService<IMobileFoodFacilityService>();
        
        await mobileFoodFacilityService.RefreshDataAsync();
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member