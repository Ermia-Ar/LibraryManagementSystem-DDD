using Shared.Domain;

namespace Core.Domain.Aggregates.Copies.Events;

public sealed record UpdatedPriceEvent(
    long CopyId,
    double Price
    ) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}
