using Shared.Domain;

namespace Core.Domain.Aggregates.Reservations.Events;

public sealed record ReservationCompletedEvent(
	long ReservationId

	) : IDomainEvent
{
	public DateTime OccurredOn { get; } = DateTime.Now;
}
