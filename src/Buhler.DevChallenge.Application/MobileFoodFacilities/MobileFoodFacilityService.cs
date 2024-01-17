using Buhler.DevChallenge.Domain.MobileFoodFacilities;
using Buhler.DevChallenge.Integration;
using Buhler.DevChallenge.Persistence.MobileFoodFacilities;

namespace Buhler.DevChallenge.Application.MobileFoodFacilities;

public class MobileFoodFacilityService : IMobileFoodFacilityService
{
    private readonly IDataSfApiIntegrationService _sfApiIntegrationService;
    private readonly IMobileFoodFacilityRepository _foodFacilityRepository;

    public MobileFoodFacilityService(IDataSfApiIntegrationService sfApiIntegrationService, IMobileFoodFacilityRepository foodFacilityRepository)
    {
        _sfApiIntegrationService = sfApiIntegrationService;
        _foodFacilityRepository = foodFacilityRepository;
    }

    public async Task RefreshDataAsync()
    {
        // TODO delete table contents before adding new data
        
        var data = await _sfApiIntegrationService.GetMobileFoodFacilitiesBatchAsync(1, 1);
        
        var mobileFoodFacilities = data.Select(x => new MobileFoodFacility(x));

        var unsavedContext = await _foodFacilityRepository.AddRangeAsync(mobileFoodFacilities);

        await unsavedContext.SaveChangesAsync();
    }
}