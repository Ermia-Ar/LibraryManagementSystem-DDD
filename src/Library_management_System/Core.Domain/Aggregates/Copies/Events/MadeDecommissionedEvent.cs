namespace Core.Domain.Aggregates.Copies.Events;

public sealed record MadeDecommissionedEvent(
    long CopyId
    ) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}