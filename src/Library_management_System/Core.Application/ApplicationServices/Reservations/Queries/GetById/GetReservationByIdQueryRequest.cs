using Shared.Mediator.Query;

namespace Core.Application.ApplicationServices.Reservations.Queries.GetById;

public sealed record GetReservationByIdQueryRequest(
    long ReservationId
    ) : IQuery<GetReservationByIdQueryResponse>;