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
        book.IsActive = false;
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
