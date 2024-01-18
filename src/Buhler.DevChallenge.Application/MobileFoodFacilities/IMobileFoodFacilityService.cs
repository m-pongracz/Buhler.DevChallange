using Buhler.DevChallenge.Domain;
using Buhler.DevChallenge.Domain.MobileFoodFacilities;
using NetTopologySuite.Geometries;

namespace Buhler.DevChallenge.Application.MobileFoodFacilities;

public interface IMobileFoodFacilityService
{
    Task RefreshDataAsync();

    Task<PagedResult<MobileFoodFacility>> SearchClosestByFoodAsync(Point location, string? foodSearchString, PagingRequest pagingRequest);
}