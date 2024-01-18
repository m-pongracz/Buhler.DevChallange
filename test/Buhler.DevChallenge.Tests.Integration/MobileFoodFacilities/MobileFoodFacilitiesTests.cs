using Buhler.DevChallenge.Persistence.MobileFoodFacilities;
using FluentAssertions;
using Xunit.Abstractions;

namespace Buhler.DevChallenge.Tests.Integration.MobileFoodFacilities;

public class MobileFoodFacilitiesTests : IntegrationTestsBase
{
    private readonly TestDataFactory _testDataFactory;
    
    public MobileFoodFacilitiesTests(TestingWebApplicationFactory factory, ITestOutputHelper outputHelper) : base(factory, outputHelper)
    {
        _testDataFactory = new TestDataFactory(12345);
    }
    
    /// <summary>
    /// Tests whether facilities are ordered by distance
    /// </summary>
    [Fact]
    public async Task FacilitiesOrderedByDistance()
    {
        // Arrange
        var repo = GetRequiredService<IMobileFoodFacilityRepository>();

        await (await repo.AddRangeAsync(new[]
        {
            _testDataFactory.CreateMobileFoodFacility(locationId: 1, longitude: 1, latitude: 0, facilityName: "a"),
            _testDataFactory.CreateMobileFoodFacility(locationId: 2, longitude: 2, latitude: 0, facilityName: "b"),
            _testDataFactory.CreateMobileFoodFacility(locationId: 3, longitude: 0, latitude: 4, facilityName: "c"),
        })).SaveChangesAsync();

        // Act
        var res = await WebApiClient.SearchAsync(2, 2);

        // Assert
        res.Data.Select(x => x.FacilityName).Should().Equal(new [] {"b", "a", "c"}, "facilities are ordered by distance");
    }    
    
    /// <summary>
    /// Tests whether facilities are ordered by distance
    /// </summary>
    [Fact]
    public async Task FacilitiesFilteredByFood()
    {
        // Arrange
        var repo = GetRequiredService<IMobileFoodFacilityRepository>();

        await (await repo.AddRangeAsync(new[]
        {
            _testDataFactory.CreateMobileFoodFacility(foodItems: "hot dog"),
            _testDataFactory.CreateMobileFoodFacility(foodItems: "gyros"),
            _testDataFactory.CreateMobileFoodFacility(foodItems: "fries"),
        })).SaveChangesAsync();

        // Act
        var res = await WebApiClient.SearchAsync(food: "Hotdog");

        // Assert
        res.Data.Should().ContainSingle(x => x.FoodItems == "hot dog", "user searched for 'Hotdog'");
    }    
    
    /// <summary>
    /// Tests whether facilities are ordered by distance
    /// </summary>
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task FacilitiesNotFilteredByFoodWhenEmpty(string? foodFilter)
    {
        // Arrange
        var repo = GetRequiredService<IMobileFoodFacilityRepository>();

        await (await repo.AddRangeAsync(new[]
        {
            _testDataFactory.CreateMobileFoodFacility(foodItems: "hot dog"),
            _testDataFactory.CreateMobileFoodFacility(foodItems: "gyros"),
            _testDataFactory.CreateMobileFoodFacility(foodItems: "fries"),
        })).SaveChangesAsync();

        // Act
        var res = await WebApiClient.SearchAsync(food: foodFilter);

        // Assert
        res.Data.Count().Should().Be(3, "when filter is null or empty we return all facilities");
    }
    
    // TODO mocked API client tests
}