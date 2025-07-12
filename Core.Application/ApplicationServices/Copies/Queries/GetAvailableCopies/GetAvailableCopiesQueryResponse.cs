using Core.Domain.Aggregates.Books.ValueObjects;
using Core.Domain.Aggregates.Copies.Enums;
using Core.Domain.Aggregates.Copies.ValueObjects;
using Shared.Helper;

namespace Core.Application.ApplicationServices.Copies.Queries.GetAvailableCopies;

public sealed record GetAvailableCopiesQueryResponse(
    CopyId CopyId,
    BookId BookId,
    Title Title,
    Author Author,
    Publisher Publisher,
    PublicationDate PublicationDate,
    Price Price,
    PhysicalCondition PhysicalCondition
) : IResponse;