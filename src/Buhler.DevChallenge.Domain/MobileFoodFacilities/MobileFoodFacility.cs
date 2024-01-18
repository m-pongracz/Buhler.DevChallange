using Buhler.DevChallenge.Domain.Geography;
using Buhler.DevChallenge.Integration.Dtos;
using NetTopologySuite.Geometries;

namespace Buhler.DevChallenge.Domain.MobileFoodFacilities;

public class MobileFoodFacility
{
    protected MobileFoodFacility()
    {
        
    }

    public MobileFoodFacility(MobileFoodFacilityApiDto dto)
    {
        if (!dto.IsValid())
        {
            throw new ArgumentException("DTO is invalid.");
        }
        
        LocationId = long.Parse(dto.ObjectId!);
        FacilityName = dto.Applicant!;
        LocationDescription = dto.LocationDescription!;
        Address = dto.Address!;
        FoodItems = dto.FoodItems!;
        FoodItemsSearchOptimized = FoodItems.ToLowerInvariant().Replace(" ", string.Empty);
        Location = LocationUtils.CreatePoint(double.Parse(dto.Longitude!), double.Parse(dto.Latitude!));
        CreatedAt = DateTimeOffset.UtcNow;
    }
    
    public long LocationId { get; protected init; }
    public string FacilityName { get; protected init; } = null!;
    public string LocationDescription { get; protected init; } = null!;
    public string Address { get; protected init; } = null!;
    public string FoodItems { get; protected init; } = null!;
    public string FoodItemsSearchOptimized { get; protected init; } = null!;
    public Point Location { get; protected init; } = null!;
    public DateTimeOffset CreatedAt { get; protected init; }
}