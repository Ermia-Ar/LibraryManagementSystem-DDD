namespace Core.Application.ApplicationServices.Reservations.Commands.Expire;

public sealed record ExpireReservationCommandRequest(
    long ReservationId    
    ) : ICommand;