namespace Core.Domain.Aggregates.Users.Events;

public sealed record ReservationIdAddedEvent(
    long UserId,
    long ReservationId

): IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}