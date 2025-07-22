﻿using Core.Domain.Aggregates.Copies.Enums;
using Shared.Domain;

namespace Core.Domain.Aggregates.Copies.Events;

public sealed record CopyCreatedEvent(
    long BookId,
    double Price,
    PhysicalCondition Condition

    ) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}
