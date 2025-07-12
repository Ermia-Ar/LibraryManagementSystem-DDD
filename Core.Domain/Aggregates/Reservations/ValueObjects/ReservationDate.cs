using Shared.Domain;

namespace Core.Domain.Aggregates.Reservations.ValueObjects;

public class ReservationDate : ValueObject<ReservationDate>
{
    public DateTime Date { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Date;
    }

    public static ReservationDate Create(DateTime date)
    {
        if (date <= DateTime.Now) throw new ArgumentException();

        return new ReservationDate { Date = date };
    }

	public override string ToString()
	=> Date.ToString();

	public DateTime ToDateTime()
		=> Date;
}