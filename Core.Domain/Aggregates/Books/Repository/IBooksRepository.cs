using Core.Domain.Aggregates.Books.ValueObjects;

namespace Core.Domain.Aggregates.Books.Repository;

public interface IBooksRepository
{
    //Commands
    Book Add(Book book);
    
    void Remove(Book book);
    //Query
    Task<bool> BookIsExistedById(int id, CancellationToken token);
    
    Task<Book?> FindById(long id, CancellationToken token);
}
