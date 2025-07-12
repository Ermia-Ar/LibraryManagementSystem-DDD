using Core.Domain.Aggregates.Copies.Enums;
using Shared.Domain;

namespace Core.Domain.Aggregates.Copies.Events;

public sealed record UpdatedPhysicalConditionEvent(
    Guid CopyId,
    Guid BookId,
    PhysicalCondition Condition
    ) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}
