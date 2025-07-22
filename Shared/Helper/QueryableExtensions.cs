namespace Shared.Helper;

public static class ListExtensions
{
    public static PaginatedResult<T> ToPaginatedList<T>(this ICollection<T> source, PaginationFiltering pagination)
        where T : class
    {
        if (source == null)
            throw new Exception("Empty");
        
        var pageNumber = pagination.PageNumber == 0 ? 1 : pagination.PageNumber;
        var pageSize = pagination.PageSize == 0 ? 10 : pagination.PageSize;
        
        int count = source.Count();
        if (count == 0)
            return PaginatedResult<T>.Success(new List<T>(), count, pageNumber, pageSize);
        
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        
        return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
    }
}