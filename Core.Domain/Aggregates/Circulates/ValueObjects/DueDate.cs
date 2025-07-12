using Shared.Domain;

namespace Core.Domain.Aggregates.Circulates.ValueObjects;

public class DueDate : ValueObject<DueDate>
{
	public DateTime Date { get; init; }

	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Date;
	}

	public static DueDate Create(DateTime date)
	{
		if (date <= DateTime.Now) throw new ArgumentException();

		return new DueDate { Date = date };
	}


	public override string ToString()
		=> Date.ToString();

	public DateTime ToDateTime()
		=> Date;
}