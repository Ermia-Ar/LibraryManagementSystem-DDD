using Shared.Domain;

namespace Core.Domain.Aggregates.Copies.Events;

public sealed record UpdatedPriceEvent(
    Guid CopyId,
    Guid BookId,
    double Price
    ) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}
