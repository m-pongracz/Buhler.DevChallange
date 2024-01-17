using Buhler.DevChallenge.Domain.MobileFoodFacilities;

namespace Buhler.DevChallenge.Persistence.MobileFoodFacilities;

public class MobileFoodFacilityRepository : EfRepositoryBase<long, MobileFoodFacility>, IMobileFoodFacilityRepository
{
    public MobileFoodFacilityRepository(DevChallengeDbContext dbContext) : base(dbContext)
    {
    }
}