using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Buhler.DevChallenge.Domain.Settings;

namespace Buhler.DevChallenge.Persistence.Migrations;

// ReSharper disable once ClassNeverInstantiated.Global
public class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Environment.ExitCode = 1;
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(builder =>
            {
                builder
                    .AddConsole();
            })
            .ConfigureAppConfiguration(ConfigureBuilder)
            .ConfigureServices((hbc, service) =>
            {
                service.Configure<DbConnectionSettings>(hbc.Configuration.GetSection(DbConnectionSettings.SectionName));
                
                service
                    .AddHostedService<InitializationHostedService>()
                    .AddScoped<IMigrationService, MigrationService>()
                    .AddPersistence();
            });
    
    
    private static void ConfigureBuilder(HostBuilderContext hostBuilderContext, IConfigurationBuilder configurationBuilder)
    {
        var env = hostBuilderContext.HostingEnvironment;
        
        configurationBuilder
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
    }
}
