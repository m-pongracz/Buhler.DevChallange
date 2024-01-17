using Buhler.DevChallenge.Application.MobileFoodFacilities;
using Microsoft.AspNetCore.Mvc;

namespace Buhler.DevChallenge.WebApi.Controllers;

/// <summary>
/// Quizes controller.
/// </summary>
[ApiController]
[Route("api/v1/mobile-food-facility")]
public class MobileFoodFacilityController : ControllerBase
{
    private readonly IMobileFoodFacilityService _mobileFoodFacilityService;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public MobileFoodFacilityController(IMobileFoodFacilityService mobileFoodFacilityService)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        _mobileFoodFacilityService = mobileFoodFacilityService;
    }

    // /// <summary>
    // /// Returns a list of quizes.
    // /// </summary>
    // /// <param name="quizCategory">Quiz category for filtering</param>
    // /// <param name="pagingRequestDto">Paging request</param>
    // /// <returns>Nothing</returns>
    // /// <response code="200">Quizes were queried successfully</response>
    // /// <response code="401">User is not logged in</response>
    // [HttpGet]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<QuizMetadataDto>))]
    // [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null!)]
    // public async Task<ActionResult<IEnumerable<QuizMetadataDto>>> List([FromQuery] [Required] QuizCategory quizCategory, [FromQuery] PagingRequestDto pagingRequestDto)
    // {
    //     var quizes = await _quizesService.GetAllInCategoryAsync(quizCategory, pagingRequestDto.GetPagingRequest());
    //
    //     return Ok(quizes.Select(QuizMetadataDto.Create));
    // }  
    
}