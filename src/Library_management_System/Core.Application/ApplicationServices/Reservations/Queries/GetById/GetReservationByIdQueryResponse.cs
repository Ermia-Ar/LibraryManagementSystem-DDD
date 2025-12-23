namespace Core.Application.ApplicationServices.Reservations.Queries.GetById;

public sealed record GetReservationByIdQueryResponse(
    string BookName,
    string UserFullName,
    DateTime ReservationDate,
    ReservationStatus Status
    ) : IResponse;