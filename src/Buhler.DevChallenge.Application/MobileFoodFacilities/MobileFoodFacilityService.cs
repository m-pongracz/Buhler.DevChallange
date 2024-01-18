using Buhler.DevChallenge.Domain.MobileFoodFacilities;
using Buhler.DevChallenge.Integration;
using Buhler.DevChallenge.Integration.Dtos;
using Buhler.DevChallenge.Persistence.MobileFoodFacilities;

namespace Buhler.DevChallenge.Application.MobileFoodFacilities;

public class MobileFoodFacilityService : IMobileFoodFacilityService
{
    private readonly IDataSfApiIntegrationService _sfApiIntegrationService;
    private readonly IMobileFoodFacilityRepository _foodFacilityRepository;

    private const int RefreshBatchSize = 50;

    public MobileFoodFacilityService(IDataSfApiIntegrationService sfApiIntegrationService,
        IMobileFoodFacilityRepository foodFacilityRepository)
    {
        _sfApiIntegrationService = sfApiIntegrationService;
        _foodFacilityRepository = foodFacilityRepository;
    }

    public async Task RefreshDataAsync()
    {
        await _foodFacilityRepository.ClearAsync();

        for (var offset = 0;; offset += RefreshBatchSize)
        {
            var data = (await _sfApiIntegrationService.GetMobileFoodFacilitiesBatchAsync(offset, RefreshBatchSize)).ToArray();
            
            var mobileFoodFacilities = data.Where(IsFoodFacilityApiDtoValid).Select(x => new MobileFoodFacility(x));

            var unsavedContext = await _foodFacilityRepository.AddRangeAsync(mobileFoodFacilities);

            await unsavedContext.SaveChangesAsync();
            
            _foodFacilityRepository.ClearChangeTracker();
            
            if (data.Length < RefreshBatchSize)
            {
                break;
            }
        }
    }
    
    private static bool IsFoodFacilityApiDtoValid(MobileFoodFacilityApiDto dto)
    {
        return dto is
        {
            Applicant: not null, 
            Longitude: not null, 
            Latitude: not null, 
            Address: not null,
            LocationDescription: not null, 
            FoodItems: not null, 
            ObjectId: not null
        };
    }
}