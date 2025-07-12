using Shared.Domain;

namespace Core.Domain.Aggregates.Circulates.ValueObjects;

public class ReturnDate : ValueObject<ReturnDate>
{
	public DateTime? Date { get; init; }

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