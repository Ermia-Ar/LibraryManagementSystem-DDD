namespace Core.Domain.Aggregates.Books.ValueObjects;

public sealed class Publisher : ValueObject<Publisher>
{
    public string Name { get; init; } = null!;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }

    public static Publisher Create(string name)
    {
        if (name.Length <= 5)
        {
            throw new ArgumentNullException();
        }
        
        return new Publisher { Name = name };
    }
    
    public override string ToString()
        => Name;
}