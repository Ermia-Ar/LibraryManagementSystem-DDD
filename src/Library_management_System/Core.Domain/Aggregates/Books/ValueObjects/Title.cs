namespace Core.Domain.Aggregates.Books.ValueObjects;

public sealed class Title : ValueObject<Title>
{
    public string Content { get; init; } = null!;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Content;
    }

    public static Title Create(string content)
    {
        if (content.Length <= 3)
        {
            throw new ArgumentException("Are You Ok ??");
        }
        
        return new Title { Content = content };
    }
    
    public override string ToString()
        => Content;

}