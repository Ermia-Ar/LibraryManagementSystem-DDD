namespace Core.Domain.Aggregates.Copies.Events;

public sealed record MadeCopyBorrowedEvent(
    long CopyId
) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}