using Buhler.DevChallenge.Domain;
using Buhler.DevChallenge.Domain.MobileFoodFacilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NetTopologySuite.Geometries;

namespace Buhler.DevChallenge.Persistence.MobileFoodFacilities;

public class MobileFoodFacilityRepository : EfRepositoryBase<long, MobileFoodFacility>, IMobileFoodFacilityRepository
{
    public MobileFoodFacilityRepository(DevChallengeDbContext dbContext) : base(dbContext)
    {
    }

    public async Task ClearAsync(CancellationToken cancellationToken = default)
    {
        await DbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {nameof(DbContext.MobileFoodFacilities)}", cancellationToken: cancellationToken);
        ClearChangeTracker();
    }

    public async Task<PagedResult<MobileFoodFacility>> SearchClosestByFoodAsync(Point location, string? foodSearchString, PagingRequest pagingRequest)
    {
        var (skip, take) = pagingRequest.GetSkipAndTake();

        var query = Entities.AsQueryable();

        if (!foodSearchString.IsNullOrEmpty())
        {
            query = query.Where(x => x.FoodItemsSearchOptimized.Contains(foodSearchString!.ToLowerInvariant()));
        }
        
        var data = await query
            .OrderBy(x => x.Location.Distance(location))
            .Skip(skip)
            .Take(take)
            .ToArrayAsync();

        return new PagedResult<MobileFoodFacility>(pagingRequest, data);
    }
}