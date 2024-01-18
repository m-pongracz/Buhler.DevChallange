namespace Buhler.DevChallenge.WebApi;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        await host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        // We have to set Environment Variable due to migration command process
        return Host.CreateDefaultBuilder(args)
            .ConfigureLogging(builder =>
            {
                builder.AddConsole();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
