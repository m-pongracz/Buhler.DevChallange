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
        var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);
        
        LocationId = long.Parse(dto.ObjectId);
        FacilityName = dto.Applicant;
        LocationDescription = dto.LocationDescription;
        Address = dto.Address;
        FoodItems = dto.FoodItems;
        FoodItemsSearchOptimized = FoodItems.ToLowerInvariant().Replace(" ", string.Empty);
        Location = gf.CreatePoint(new Coordinate(double.Parse(dto.Longitude), double.Parse(dto.Latitude)));
    }
    
    public long LocationId { get; protected set; }
    public string FacilityName { get; protected set; } = null!;
    public string LocationDescription { get; protected set; } = null!;
    public string Address { get; protected set; } = null!;
    public string FoodItems { get; protected set; } = null!;
    public string FoodItemsSearchOptimized { get; protected set; } = null!;
    public Point Location { get; protected set; } = null!;
}