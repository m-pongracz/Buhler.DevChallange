using System.Text.Json.Serialization;

namespace Buhler.DevChallenge.Integration.Dtos;

public class MobileFoodFacilityApiDto
{
    public MobileFoodFacilityApiDto()
    {
        
    }
    
    [JsonPropertyName("objectid")]
    public string? ObjectId { get; set; }

    [JsonPropertyName("applicant")]
    public string? Applicant { get; set; }
    
    [JsonPropertyName("locationdescription")]
    public string? LocationDescription { get; set; }
    
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("fooditems")]
    public string? FoodItems { get; set; }

    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }
    
    
    public bool IsValid()
    {
        return this is
        {
            Applicant: not null, 
            Longitude: not null, 
            Latitude: not null, 
            Address: not null,
            LocationDescription: not null, 
            FoodItems: not null, 
            ObjectId: not null
        };
    }
}