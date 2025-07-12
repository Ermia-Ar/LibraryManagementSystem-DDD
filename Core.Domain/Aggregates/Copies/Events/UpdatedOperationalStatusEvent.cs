using Core.Domain.Aggregates.Copies.Enums;
using Shared.Domain;

namespace Core.Domain.Aggregates.Copies.Events;

public sealed record UpdatedOperationalStatusEvent(
    Guid CopyId,
    Guid BookId,
    OperationalStatus status
    ) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}
