using Core.Domain.Aggregates.Reservations.Enums;
using Shared.Helper;

namespace Core.Application.ApplicationServices.Users.Queries.GetReservations;

public sealed record GetReservationsForUserQueryResponse(
    string BookName,
    string UserFullName,
    DateTime ReservationDate,
    ReservationStatus Status
) : IResponse;