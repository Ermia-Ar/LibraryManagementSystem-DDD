namespace Core.Application.ApplicationServices.Reservations.Commands.Cancel;

public sealed record CancelReservationCommandRequest(
    long ReservationId    
    ) : ICommand;