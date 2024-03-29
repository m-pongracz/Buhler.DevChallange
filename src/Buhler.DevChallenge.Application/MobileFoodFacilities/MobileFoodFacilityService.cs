﻿using Buhler.DevChallenge.Domain;
using Buhler.DevChallenge.Domain.MobileFoodFacilities;
using Buhler.DevChallenge.Integration;
using Buhler.DevChallenge.Persistence.MobileFoodFacilities;
using NetTopologySuite.Geometries;

namespace Buhler.DevChallenge.Application.MobileFoodFacilities;

public class MobileFoodFacilityService : IMobileFoodFacilityService
{
    private readonly IDataSfApiIntegrationService _sfApiIntegrationService;
    private readonly IMobileFoodFacilityRepository _foodFacilityRepository;

    // TODO with EFCore.BulkExtensions should be set to around 2000
    private const int RefreshBatchSize = 50;

    public MobileFoodFacilityService(IDataSfApiIntegrationService sfApiIntegrationService,
        IMobileFoodFacilityRepository foodFacilityRepository)
    {
        _sfApiIntegrationService = sfApiIntegrationService;
        _foodFacilityRepository = foodFacilityRepository;
    }

    public async Task RefreshDataAsync()
    {
        // TODO should be done in a transaction so we don't delete our data before we can save the new data
        
        await _foodFacilityRepository.ClearAsync();

        for (var offset = 0;; offset += RefreshBatchSize)
        {
            var data = (await _sfApiIntegrationService.GetMobileFoodFacilitiesBatchAsync(offset, RefreshBatchSize)).ToArray();
            
            var mobileFoodFacilities = data.Where(x => x.IsValid()).Select(x => new MobileFoodFacility(x));
            
            // TODO can be done better with EFCore.BulkExtensions
            var unsavedContext = await _foodFacilityRepository.AddRangeAsync(mobileFoodFacilities);

            await unsavedContext.SaveChangesAsync();
            
            _foodFacilityRepository.ClearChangeTracker();
            
            if (data.Length < RefreshBatchSize)
            {
                break;
            }
        }
    }

    public Task<PagedResult<MobileFoodFacility>> SearchClosestByFoodAsync(Point location, string? foodSearchString, PagingRequest pagingRequest)
    {
        return _foodFacilityRepository.SearchClosestByFoodAsync(location, foodSearchString, pagingRequest);
    }
}