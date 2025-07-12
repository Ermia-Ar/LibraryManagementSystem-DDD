namespace Shared.Helper;

public sealed class PaginationRequest
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PaginationRequest(int pageNumber, int pageSize)
    {
        pageNumber = pageNumber == 0 ? 1 : pageNumber;
        pageSize = pageSize == 0 ? 10 : pageSize;
    }
}
