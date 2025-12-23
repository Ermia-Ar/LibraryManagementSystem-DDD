namespace Core.Domain.Aggregates.Copies.Events;

public sealed record MadeCopyReservedEvent(
    long CopyId
) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}