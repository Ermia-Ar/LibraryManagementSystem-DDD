using Core.Domain.Aggregates.Books.Enums;
using Shared.Domain;

namespace Core.Domain.Aggregates.Books.Events;

public sealed record RemovedGenreEvent(
    long BookId,
    Genre Genre
) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}