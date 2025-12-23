namespace Core.Domain.Aggregates.Copies.Events;

public sealed record MadeCopyAvailableEvent(
    long CopyId
) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}