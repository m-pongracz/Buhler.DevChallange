using Buhler.DevChallenge.Domain;

namespace Buhler.DevChallenge.WebApi.Dtos;

/// <summary>
/// Paging request DTO
/// </summary>
public class PagingRequestDto
{
    /// <summary>
    /// PageNumber to load. 1-indexed. Default is 1.
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// Page size. Default is 100.
    /// </summary>
    public int PageSize { get; set; } = 100;

    internal PagingRequest GetPagingRequest()
    {
        return new PagingRequest(PageNumber, PageSize);
    }
}