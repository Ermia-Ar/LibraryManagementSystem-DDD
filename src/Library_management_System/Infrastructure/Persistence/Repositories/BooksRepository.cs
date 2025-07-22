using Core.Domain.Aggregates.Books;
using Core.Domain.Aggregates.Books.Repository;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class BooksRepository(ApplicationContext context) : IBooksRepository
{
    private readonly ApplicationContext _context = context;

    public Book Add(Book book)
    {
        return _context.Books.Add(book).Entity;
    }
    
    public void Remove(Book book)
    {
        _context.Books.Remove(book);
    }

    public async Task<bool> BookIsExistedById(int id, CancellationToken token)
    {
       var book = await _context.Books
            .FirstOrDefaultAsync(x => x.Id == id, token);
        
        return book != null;
    }

    public async Task<Book?> FindById(long id, CancellationToken token)
    {
        return await _context.Books
            .FirstOrDefaultAsync(x => x.Id == id, token);
    }
}
