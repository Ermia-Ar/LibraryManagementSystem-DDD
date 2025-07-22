using Core.Domain.Aggregates.Copies.Enums;
using Shared.Domain;

namespace Core.Domain.Aggregates.Copies.Events;

public sealed record MadeCopyAvailableEvent(
    long CopyId
) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}