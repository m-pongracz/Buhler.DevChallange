using Buhler.DevChallenge.Integration.Dtos;

namespace Buhler.DevChallenge.Integration;

public interface IDataSfApiIntegrationService
{
    Task<IEnumerable<MobileFoodFacilityApiDto>> GetMobileFoodFacilitiesBatchAsync(int offset, int limit);
}