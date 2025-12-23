namespace Core.Application.ApplicationServices.Reservations.Commands.Complete;

public sealed record CompleteReservationCommandRequest(
    long ReservationId    
) : ICommand;