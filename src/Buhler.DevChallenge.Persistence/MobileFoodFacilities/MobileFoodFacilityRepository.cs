using Buhler.DevChallenge.Domain.MobileFoodFacilities;
using Microsoft.EntityFrameworkCore;

namespace Buhler.DevChallenge.Persistence.MobileFoodFacilities;

public class MobileFoodFacilityRepository : EfRepositoryBase<long, MobileFoodFacility>, IMobileFoodFacilityRepository
{
    public MobileFoodFacilityRepository(DevChallengeDbContext dbContext) : base(dbContext)
    {
    }

    public Task ClearAsync(CancellationToken cancellationToken = default)
    {
        return DbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {nameof(DbContext.MobileFoodFacilities)}", cancellationToken: cancellationToken);
    }
}