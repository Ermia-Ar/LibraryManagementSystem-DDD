using Core.Domain.Aggregates.Books;
using Core.Domain.Aggregates.Books.Repository;
using Core.Domain.Aggregates.Books.ValueObjects;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class BooksRepository(ApplicationContext context) : IBooksRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<bool> BookIsExistedById(BookId id, CancellationToken token)
    {
       var book = await _context.Books
            .FirstOrDefaultAsync(x => x.Id == id, token);
        
        return book != null;
    }

    public void Add(Book book)
    {
        _context.Books.Add(book);
    }
}
