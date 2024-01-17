using System.Text.Json.Serialization;
using Buhler.DevChallenge.Application;
using Buhler.DevChallenge.Persistence;

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
        
        services.AddSettings(_configuration);
        
        services.AddPersistence();
        
        services.AddApplicationServices();
    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        // if (env.IsDevelopment())
        // {
        // }

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
        
        using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        
        // TODO fill DB ??
        
        // var dbInitializer = scope.ServiceProvider.GetRequiredService<ITriviaBotDatabaseInitializer>();
            
        // dbInitializer.Initialize();
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member