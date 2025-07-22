using Shared.Domain;

namespace Core.Domain.Aggregates.Books.Events;

public sealed record CopyRemovedEvent(
    long CopyId,
    long BookId

): IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}