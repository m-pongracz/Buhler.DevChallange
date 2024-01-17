using NetTopologySuite.Geometries;

namespace Buhler.DevChallenge.Domain.MobileFoodFacilities;

public class MobileFoodFacility
{
    protected MobileFoodFacility()
    {
        
    }
    
    public long LocationId { get; protected set; }
    public string FacilityName { get; protected set; } = null!;
    public string LocationDescription { get; protected set; } = null!;
    public string Address { get; protected set; } = null!;
    public string FoodItems { get; protected set; } = null!;
    public string FoodItemsSearchOptimized { get; protected set; } = null!;
    public Point Location { get; protected set; } = null!;
}