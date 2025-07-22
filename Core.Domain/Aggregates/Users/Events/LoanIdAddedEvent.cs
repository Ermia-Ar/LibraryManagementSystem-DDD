using Shared.Domain;

namespace Core.Domain.Aggregates.Users.Events;

public sealed record LoanIdAddedEvent(
    long UserId,
    long CheckOutId

): IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}