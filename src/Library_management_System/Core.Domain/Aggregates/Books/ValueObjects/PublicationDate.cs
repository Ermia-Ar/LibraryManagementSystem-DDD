namespace Core.Domain.Aggregates.Books.ValueObjects;

public class PublicationDate : ValueObject<PublicationDate>
{
    public DateTime Date { get; init; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Date;
    }

    public static PublicationDate Create(DateTime date)
    {
        if (date >= DateTime.Now)
        {
            throw new ArgumentException($"{nameof(date)} must be before Now");
        }
        return new PublicationDate(){ Date = date};
    }
    
    public override string ToString()
        => $"{Date.Year}-{Date.Month}-{Date.Day}";

    public DateTime ToDateTime() 
        => Date;
}

    
    