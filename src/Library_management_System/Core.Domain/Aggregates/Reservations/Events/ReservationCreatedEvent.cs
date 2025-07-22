using Shared.Domain;

namespace Core.Domain.Aggregates.Reservations.Events;

public sealed record ReservationCreatedEvent(
	long CopyId,
	long UserId,
	DateTime ReservationDate

	) : IDomainEvent
{
	public DateTime OccurredOn { get; } = DateTime.Now;
}
