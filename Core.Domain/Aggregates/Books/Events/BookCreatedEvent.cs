using Shared.Domain;

namespace Core.Domain.Aggregates.Books.Events;

public sealed record BookCreatedEvent(
    Guid BookId,
    string Title,
    string Author,
    string Publisher,
    DateTime PublicationDate
    ) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}

