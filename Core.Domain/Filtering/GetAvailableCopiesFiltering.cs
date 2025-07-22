using Core.Domain.Aggregates.Books.Enums;
using Core.Domain.Aggregates.Copies.Enums;

namespace Core.Domain.Filtering;

public sealed record  GetAvailableCopiesFiltering(
    string? Title,
    string? Author,
    string? Publisher,
    PhysicalCondition? PhysicalCondition,
    Double? Price,
    Genre? Genre
    );