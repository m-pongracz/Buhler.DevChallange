using System.Text.Json;
using Buhler.DevChallenge.Integration.Dtos;

namespace Buhler.DevChallenge.Integration;

public class DataSfApiIntegrationService : IDataSfApiIntegrationService
{
    private const string UriString = "https://data.sfgov.org/resource/rqzj-sfat.json";
    
    public async Task<IEnumerable<MobileFoodFacilityApiDto>> GetMobileFoodFacilitiesBatchAsync(int offset, int limit)
    {
        var path = $"?$order=objectid&$limit={limit}&$offset={offset}";
        
        using var client = new HttpClient();

        client.BaseAddress = new Uri(UriString);

        var response = await client.GetAsync(path);

        // TODO throw better exceptions
        response.EnsureSuccessStatusCode();
        
        var stream = await response.Content.ReadAsStreamAsync();

        return (await JsonSerializer.DeserializeAsync<MobileFoodFacilityApiDto[]>(stream))!;
    }
}