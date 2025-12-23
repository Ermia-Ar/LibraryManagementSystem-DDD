namespace Core.Domain.Aggregates.Books.ValueObjects;

public class Author : ValueObject<Author>
{
    public string FullName { get; init; } = null!;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return FullName;
    }

    public static Author Create(string fullName)
    {
        if (fullName.Length < 5)
        {
            throw new ArgumentException();
        }
        
        return new Author { FullName = fullName };
    }
    
    public override string ToString()
        => FullName;    
}