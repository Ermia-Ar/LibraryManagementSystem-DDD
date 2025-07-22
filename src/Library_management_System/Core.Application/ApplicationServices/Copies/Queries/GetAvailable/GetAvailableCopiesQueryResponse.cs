using Core.Domain.Aggregates.Copies.Enums;
using Shared.Helper;

namespace Core.Application.ApplicationServices.Copies.Queries.GetAvailable;

public sealed record GetAvailableCopiesQueryResponse(
    long Id,
    long BookId,
    string Title,
    string Author,
    string Publisher,
    DateTime PublicationDate,
    double Price,
    PhysicalCondition PhysicalCondition,
    string Genres
) : IResponse;