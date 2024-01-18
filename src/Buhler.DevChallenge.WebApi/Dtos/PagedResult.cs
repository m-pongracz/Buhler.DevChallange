using Buhler.DevChallenge.Domain;

namespace Buhler.DevChallenge.WebApi.Dtos;

/// <summary>
/// Paged result DTO
/// </summary>
/// <typeparam name="TData">Domain data type</typeparam>
/// <typeparam name="TDto">DTO data type</typeparam>
public class PagedResultDto<TData, TDto>
{
    /// <summary>
    /// Page number
    /// </summary>
    public int PageNumber { get; }
    
    /// <summary>
    /// Page size
    /// </summary>
    public int PageSize { get; }
    
    /// <summary>
    /// Page data
    /// </summary>
    public IEnumerable<TDto> Data { get; }

    
    internal PagedResultDto(PagedResult<TData> pagedResult, Func<TData, TDto> getDto)
    {
        PageNumber = pagedResult.PageNumber;
        PageSize = pagedResult.PageSize;

        Data = pagedResult.Select(getDto);
    }    
}