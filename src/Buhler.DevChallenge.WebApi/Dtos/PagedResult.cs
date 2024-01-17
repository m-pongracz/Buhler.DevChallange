using Buhler.DevChallenge.Domain;

namespace Buhler.DevChallenge.WebApi.Dtos;

public class PagedResultDto<TData, TDto>
{
    public int PageNumber { get; }
    public int PageSize { get; }
    
    public IEnumerable<TDto> Data { get; } = new List<TDto>();

    public PagedResultDto()
    {
        
    }
    
    public PagedResultDto(PagedResult<TData> pagedResult, Func<TData, TDto> getDto)
    {
        PageNumber = pagedResult.PageNumber;
        PageSize = pagedResult.PageSize;

        Data = pagedResult.Select(getDto);
    }    
}