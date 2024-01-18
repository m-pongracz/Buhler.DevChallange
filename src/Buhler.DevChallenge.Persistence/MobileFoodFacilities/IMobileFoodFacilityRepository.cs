using Buhler.DevChallenge.Domain.MobileFoodFacilities;

namespace Buhler.DevChallenge.Persistence.MobileFoodFacilities;

public interface IMobileFoodFacilityRepository
{
    Task<UnsavedContext> AddRangeAsync(IEnumerable<MobileFoodFacility> entities, CancellationToken cancellationToken = default);
    
    Task ClearAsync(CancellationToken cancellationToken = default);

    void ClearChangeTracker();
}