using Buhler.DevChallenge.Domain.MobileFoodFacilities;

namespace Buhler.DevChallenge.WebApi.Dtos;

/// <summary>
/// Mobile food facility DTO
/// </summary>
public class MobileFoodFacilityDto
{
    /// <summary>
    /// Location unique identifier
    /// </summary>
    public long LocationId { get; private set; }
    
    /// <summary>
    /// Facility name
    /// </summary>
    public string FacilityName { get; private set; } = null!;
    
    /// <summary>
    /// Description of the location of the facility
    /// </summary>
    public string LocationDescription { get; private set; } = null!;
    
    /// <summary>
    /// Facility address
    /// </summary>
    public string Address { get; private set; } = null!;
    
    /// <summary>
    /// Food items served in the facility 
    /// </summary>
    public string FoodItems { get; private set; } = null!;
    
    /// <summary>
    /// Facility latitude
    /// </summary>
    public double Latitude { get; private set; }
    
    /// <summary>
    /// Facility longitude
    /// </summary>
    public double Longitude { get; private set; }
    
    /// <summary>
    /// When the facility data was pulled from the source
    /// </summary>
    public DateTimeOffset PulledFromSourceAt { get; private set; }
    
    internal static MobileFoodFacilityDto Create(MobileFoodFacility mobileFoodFacility)
    {
        return new MobileFoodFacilityDto
        {
            LocationId = mobileFoodFacility.LocationId,
            FacilityName = mobileFoodFacility.FacilityName,
            LocationDescription = mobileFoodFacility.LocationDescription,
            Address = mobileFoodFacility.Address,
            FoodItems = mobileFoodFacility.FoodItems,
            Latitude = mobileFoodFacility.Location.Y,
            Longitude = mobileFoodFacility.Location.X,
            PulledFromSourceAt = mobileFoodFacility.CreatedAt
        };
    }
}