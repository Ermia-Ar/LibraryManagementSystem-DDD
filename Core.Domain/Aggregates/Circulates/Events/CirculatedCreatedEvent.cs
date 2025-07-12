using Shared.Domain;

namespace Core.Domain.Aggregates.Circulates.Events;

public sealed record CirculatedCreatedEvent(
	Guid CirculatedId,
	Guid CopyId,
	Guid UserId,
	DateTime BorrowDate,
	DateTime DueDate
	) : IDomainEvent
{
	public DateTime OccurredOn { get; } = DateTime.Now;
}
