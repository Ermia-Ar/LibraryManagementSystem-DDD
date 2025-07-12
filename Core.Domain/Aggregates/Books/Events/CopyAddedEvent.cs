using Core.Domain.Aggregates.Copies.Enums;
using Shared.Domain;

namespace Core.Domain.Aggregates.Books.Events;

public sealed record CopyAddedEvent(
    Guid CopyId,
    Guid BookId

    ): IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}
    
