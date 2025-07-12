using Core.Domain.Aggregates.Copies.Enums;
using Core.Domain.Aggregates.Copies.ValueObjects;
using Core.Domain.Filtering;
using Shared.Helper;
using Shared.Query;

namespace Core.Application.ApplicationServices.Copies.Queries.GetAvailableCopies;

public sealed record GetAvailableCopiesQueryRequest(
    PaginationRequest Pagination,
    GetAvailableCopiesFiltering Filtering

) : IQuery<List<GetAvailableCopiesQueryResponse>>
{
    public static GetAvailableCopiesQueryRequest Create(GetAvailableCopiesDto model)
        => new GetAvailableCopiesQueryRequest
        (
            new PaginationRequest(model.PageNumber, model.PageSize),
            new GetAvailableCopiesFiltering(model.PhysicalCondition, model.Price)
        );
    }


public sealed record class GetAvailableCopiesDto(
    int PageNumber,
    int PageSize,
    PhysicalCondition PhysicalCondition,
    Price Price
);    