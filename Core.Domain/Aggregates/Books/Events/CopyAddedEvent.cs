using Core.Domain.Aggregates.Copies.Enums;
using Shared.Domain;

namespace Core.Domain.Aggregates.Books.Events;

public sealed record CopyAddedEvent(
    long CopyId,
    long BookId

    ): IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}