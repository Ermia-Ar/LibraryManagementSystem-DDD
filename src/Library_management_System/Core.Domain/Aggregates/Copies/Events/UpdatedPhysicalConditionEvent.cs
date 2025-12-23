namespace Core.Domain.Aggregates.Copies.Events;

public sealed record UpdatedPhysicalConditionEvent(
    long CopyId,
    PhysicalCondition Condition
    ) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}
