using Shared.Domain;

namespace Core.Domain.Aggregates.Circulates.Events;

public sealed record ReturnedBookEvent(
	Guid CirculatedId

	) : IDomainEvent
{
	public DateTime OccurredOn { get; } = DateTime.Now;
}
