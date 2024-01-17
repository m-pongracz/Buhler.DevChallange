using System.Text.Json.Serialization;

namespace Buhler.DevChallenge.Integration.Dtos;

public class MobileFoodFacilityApiDto
{
    public MobileFoodFacilityApiDto()
    {
        
    }
    
    [JsonPropertyName("objectid")]
    public string ObjectId { get; set; } = null!;

    [JsonPropertyName("applicant")]
    public string Applicant { get; set; } = null!;
    [JsonPropertyName("locationdescription")]
    public string LocationDescription { get; set; } = null!;
    [JsonPropertyName("address")]
    public string Address { get; set; } = null!;
    [JsonPropertyName("fooditems")]
    public string FoodItems { get; set; } = null!;
    [JsonPropertyName("x")]
    public string X { get; set; } = null!;

    [JsonPropertyName("y")]
    public string Y { get; set; } = null!;

    [JsonPropertyName("longitude")]
    public string Longitude { get; set; } = null!;

    [JsonPropertyName("latitude")]
    public string Latitude { get; set; } = null!;
}