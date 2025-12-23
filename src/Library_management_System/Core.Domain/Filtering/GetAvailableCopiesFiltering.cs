namespace Core.Domain.Filtering;

public sealed record  GetAvailableCopiesFiltering(
    string? Title,
    string? Author,
    string? Publisher,
    PhysicalCondition? PhysicalCondition,
    Double? Price,
    Genre? Genre
    );