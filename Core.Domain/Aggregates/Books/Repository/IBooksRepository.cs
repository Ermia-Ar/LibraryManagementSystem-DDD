using Core.Domain.Aggregates.Books.ValueObjects;

namespace Core.Domain.Aggregates.Books.Repository;

public interface IBooksRepository
{
    Task<bool> BookIsExistedById(BookId id, CancellationToken token);
    void Add(Book book);
}
