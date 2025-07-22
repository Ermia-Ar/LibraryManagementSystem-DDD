using Core.Domain.Aggregates.Reservations.Enums;
using Core.Domain.Filtering;
using Shared.Helper;
using Shared.Mediator.Query;

namespace Core.Application.ApplicationServices.Users.Queries.GetReservations;

    
public sealed record GetReservationsForUserQueryRequest(
    long UserId,
    PaginationFiltering PaginationFiltering,
    GetReservationFiltering Filtering
) : IQuery<PaginatedResult<GetReservationsForUserQueryResponse>>
{
    public static GetReservationsForUserQueryRequest Create(long userId, GetReservationsForUserQueryRequestDto model)
        => new GetReservationsForUserQueryRequest(
            userId,
            new PaginationFiltering(
                model.PageNum, model.PageSize
                ),
            new GetReservationFiltering(
                model.BookId, model.ReservationDate, model.Status
                )
        );
}
    
    
public sealed record GetReservationsForUserQueryRequestDto(
    int PageNum,
    int PageSize,
    long? BookId,
    DateTime? ReservationDate,
    ReservationStatus? Status
);