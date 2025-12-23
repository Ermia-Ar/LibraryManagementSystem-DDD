namespace Core.Domain.Aggregates.Books.Events;

public sealed record GenreAddedEvent(
    long BookId,
    Genre Genre
    ) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}