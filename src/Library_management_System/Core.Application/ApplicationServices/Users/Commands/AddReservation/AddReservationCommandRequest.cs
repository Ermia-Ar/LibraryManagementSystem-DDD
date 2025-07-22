using Core.Domain.Aggregates.Reservations.ValueObjects;
using Shared.Mediator.Command;

namespace Core.Application.ApplicationServices.Users.Commands.AddReservation;

public sealed record AddReservationCommandRequest(
    long UserId,
    long CopyId,
    ReservationDate ReservationDate
) : ICommand
{
    public static AddReservationCommandRequest Create(long userId, AddReservationCommandRequestDto model)
        => new AddReservationCommandRequest(
            userId,
            model.CopyId,
            model.ReservationDate
        );
}


public sealed record AddReservationCommandRequestDto(
    long CopyId,
    ReservationDate ReservationDate
    );