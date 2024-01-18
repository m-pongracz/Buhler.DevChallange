using Buhler.DevChallenge.Application.MobileFoodFacilities;
using Buhler.DevChallenge.Domain.Geography;
using Buhler.DevChallenge.Domain.MobileFoodFacilities;
using Buhler.DevChallenge.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Buhler.DevChallenge.WebApi.Controllers;

/// <summary>
/// Mobile food facilities controller
/// </summary>
[ApiController]
[Route("api/v1/mobile-food-facilities")]
public class MobileFoodFacilityController : ControllerBase
{
    private readonly IMobileFoodFacilityService _mobileFoodFacilityService;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public MobileFoodFacilityController(IMobileFoodFacilityService mobileFoodFacilityService)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _mobileFoodFacilityService = mobileFoodFacilityService;
    }
    
    /// <summary>
    /// Refreshes mobile food facility data from the source
    /// </summary>
    /// <returns></returns>
    [HttpPost("source-data/refresh")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> RefreshData()
    {
        await _mobileFoodFacilityService.RefreshDataAsync();
        
        return Ok();
    }      
    
    /// <summary>
    /// Finds mobile food facilities closest to the provided location based on user's food preferences
    /// </summary>
    /// <param name="latitude">Latitude serving as the query's base</param>
    /// <param name="longitude">Longitude serving as the query's base</param>
    /// <param name="food">requested food item. e.g. "hotdog". All results are returned if omitted.</param>
    /// <param name="pagingRequestDto">Paging request</param>
    /// <returns>Returns an array of mobile food facilities with paging info</returns>
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResultDto<MobileFoodFacility, MobileFoodFacilityDto>))]
    public async Task<ActionResult<PagedResultDto<MobileFoodFacility, MobileFoodFacilityDto>>> 
        SearchData([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] string? food, [FromQuery] PagingRequestDto pagingRequestDto)
    {
        var location = LocationUtils.CreatePoint(longitude, latitude);
        
        var data = await _mobileFoodFacilityService.SearchClosestByFoodAsync(location, food, pagingRequestDto.GetPagingRequest());
        
        return Ok(new PagedResultDto<MobileFoodFacility, MobileFoodFacilityDto>(data, MobileFoodFacilityDto.Create));
    }
}