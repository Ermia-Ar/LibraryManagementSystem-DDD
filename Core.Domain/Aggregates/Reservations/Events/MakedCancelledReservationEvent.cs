using Shared.Domain;

namespace Core.Domain.Aggregates.Reservations.Events;

public sealed record MakedCancelledReservationEvent(
	Guid ReservationId

	) : IDomainEvent
{
	public DateTime OccurredOn { get; } = DateTime.Now;
}
