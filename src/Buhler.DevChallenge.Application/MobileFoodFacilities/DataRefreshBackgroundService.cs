using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Buhler.DevChallenge.Application.MobileFoodFacilities;

public class DataRefreshBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<DataRefreshBackgroundService> _logger;
    private readonly TimeSpan _period = TimeSpan.FromMinutes(1);

    public DataRefreshBackgroundService(IServiceScopeFactory serviceScopeFactory,
        ILogger<DataRefreshBackgroundService> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(_period);

        while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                await using var scope = _serviceScopeFactory.CreateAsyncScope();

                var mobileFoodFacilityService = scope.ServiceProvider.GetRequiredService<IMobileFoodFacilityService>();

                await mobileFoodFacilityService.RefreshDataAsync();

                _logger.LogInformation("Refreshed data");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to refresh data using a background service");
            }
        }
    }
}