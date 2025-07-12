using Shared.Domain;

namespace Core.Domain.Aggregates.Reservations.ValueObjects;

public class ReservationId : ValueObject<ReservationId>
{
    public Guid Id { get; init; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }

    public static ReservationId Create(Guid id)
    {
        return new ReservationId { Id = id };
    }

    public Guid ToGuid()
        => Id;  
}