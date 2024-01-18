using System.Globalization;
using Buhler.DevChallenge.Domain.MobileFoodFacilities;
using Buhler.DevChallenge.Integration.Dtos;

namespace Buhler.DevChallenge.Tests.Integration;

public class TestDataFactory
{
    private readonly Random _random;

    public TestDataFactory(int? seed = null)
    {
        _random = seed.HasValue ? new Random(seed.Value) : new Random();
    }

    public MobileFoodFacility CreateMobileFoodFacility(string? facilityName = null, double? longitude = null,
        double? latitude = null, string? address = null, string? locationDescription = null, string? foodItems = null, 
        long? locationId = null)
    {
        var culture = CultureInfo.InvariantCulture;

        facilityName ??= _random.NextGuid().ToString();
        address ??= _random.NextGuid().ToString();
        locationDescription ??= _random.NextGuid().ToString();
        foodItems ??= _random.NextGuid().ToString();
        locationId ??= _random.NextInt64();
        latitude ??= _random.NextDouble();
        longitude ??= _random.NextDouble();

        return new MobileFoodFacility(new MobileFoodFacilityApiDto
        {
            Applicant = facilityName,
            Longitude = longitude.Value.ToString(culture),
            Latitude = latitude.Value.ToString(culture),
            Address = address,
            LocationDescription = locationDescription,
            FoodItems = foodItems,
            ObjectId = locationId.Value.ToString(culture),
        });
    }
}