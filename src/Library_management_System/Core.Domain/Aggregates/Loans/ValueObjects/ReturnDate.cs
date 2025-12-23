namespace Core.Domain.Aggregates.Loans.ValueObjects;

public class ReturnDate : ValueObject<ReturnDate>
{
	public DateTime Date { get; private init; }

	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Date;
	}

	public static ReturnDate Create(DateTime date)
	{
		if (date <= DateTime.Now) throw new ArgumentException();

		return new ReturnDate { Date = date };
	}

	public override string ToString()
		=> Date.ToString();

	public DateTime? ToDateTime()
		=> Date;
}