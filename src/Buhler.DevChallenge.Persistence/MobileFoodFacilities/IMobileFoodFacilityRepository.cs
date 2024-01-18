using Buhler.DevChallenge.Domain;
using Buhler.DevChallenge.Domain.MobileFoodFacilities;
using NetTopologySuite.Geometries;

namespace Buhler.DevChallenge.Persistence.MobileFoodFacilities;

public interface IMobileFoodFacilityRepository
{
    Task<UnsavedContext> AddRangeAsync(IEnumerable<MobileFoodFacility> entities, CancellationToken cancellationToken = default);
    
    Task ClearAsync(CancellationToken cancellationToken = default);

    void ClearChangeTracker();

    Task<PagedResult<MobileFoodFacility>> SearchClosestByFoodAsync(Point location, string? foodSearchString, PagingRequest pagingRequest);
}