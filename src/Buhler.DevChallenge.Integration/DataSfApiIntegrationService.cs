using System.Text.Json;
using Buhler.DevChallenge.Integration.Dtos;

namespace Buhler.DevChallenge.Integration;

public class DataSfApiIntegrationService : IDataSfApiIntegrationService
{
    public DataSfApiIntegrationService()
    {
        
    }
    
    public async Task<IEnumerable<MobileFoodFacilityApiDto>> GetMobileFoodFacilitiesBatchAsync(int offset, int limit)
    {
        var path = $"?$order=objectid&$limit={limit}&$offset={offset}";
        
        using var client = new HttpClient();
        
        client.BaseAddress = new Uri("https://data.sfgov.org/resource/rqzj-sfat.json");

        var response = await client.GetAsync(path);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Something went wrong");
        }
        
        var stream = await response.Content.ReadAsStreamAsync();

        return (await JsonSerializer.DeserializeAsync<MobileFoodFacilityApiDto[]>(stream))!;
    }
}