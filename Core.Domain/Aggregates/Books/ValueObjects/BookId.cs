using Shared.Domain;

namespace Core.Domain.Aggregates.Books.ValueObjects;
public class BookId : ValueObject<BookId>
{
    public required Guid Id { get; init; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }

    public static BookId Create(Guid id) 
        => new BookId { Id = id };
    
    public Guid ToGuid()
         => Id;
}