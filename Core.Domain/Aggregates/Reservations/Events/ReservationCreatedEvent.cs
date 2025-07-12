using Shared.Domain;

namespace Core.Domain.Aggregates.Reservations.Events;

public sealed record ReservationCreatedEvent(
	Guid ReservationId,
	Guid CopyId,
	Guid UserId,
	DateTime ReservationDate

	) : IDomainEvent
{
	public DateTime OccurredOn { get; } = DateTime.Now;
}
