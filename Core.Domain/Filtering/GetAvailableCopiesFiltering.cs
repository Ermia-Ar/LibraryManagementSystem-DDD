using Core.Domain.Aggregates.Copies.Enums;
using Core.Domain.Aggregates.Copies.ValueObjects;

namespace Core.Domain.Filtering;

public sealed record class GetAvailableCopiesFiltering(
    PhysicalCondition PhysicalCondition,
    Price Price
    );