namespace Core.Application.ApplicationServices.Copies.Queries.GetAvailable;

public sealed record GetAvailableCopiesQueryRequest(
    PaginationFiltering Pagination,
    GetAvailableCopiesFiltering Filtering

) : IQuery<PaginatedResult<GetAvailableCopiesQueryResponse>>
{
    public static GetAvailableCopiesQueryRequest Create(GetAvailableCopiesDto model)
        => new GetAvailableCopiesQueryRequest(
            new PaginationFiltering(
                model.PageNumber, model.PageSize
                ),
            new GetAvailableCopiesFiltering(
                model.Title, model.Author,
                model.Publisher, model.PhysicalCondition, model.Price, model.Genre
                )
        );
    }


public sealed record GetAvailableCopiesDto(
    int PageNumber,
    int PageSize,
    string? Title,
    string? Author,
    string? Publisher,
    PhysicalCondition? PhysicalCondition,
    Double? Price,
    Genre? Genre
);    