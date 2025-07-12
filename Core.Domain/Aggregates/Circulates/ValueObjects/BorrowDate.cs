using Shared.Domain;

namespace Core.Domain.Aggregates.Circulates.ValueObjects;

public class BorrowDate : ValueObject<BorrowDate>
{
	public DateTime Date { get; init; }
	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Date;
	}

	public static BorrowDate Create(DateTime date)
	{
		if (date < DateTime.Now)
		{
			throw new ArgumentException();
		}

		return new BorrowDate { Date = date };
	}
	

	public override string ToString()
		=> Date.ToString();

	public DateTime ToDateTime()
		=> Date;

}