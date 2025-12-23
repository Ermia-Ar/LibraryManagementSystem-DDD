namespace Core.Application.ApplicationServices.Reservations.Commands.Expire;

public sealed class ExpireReservationCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<ExpireReservationCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(ExpireReservationCommandRequest request, CancellationToken cancellationToken)
    {
        //check reservationId
        var reservation = await _unitOfWork.Reservations
            .FindById(request.ReservationId, cancellationToken);
        if (reservation is null)
            return ResponseHandler.NotFound("Reservation not found");
        
        var copy = await _unitOfWork.Copies
            .FindById(reservation.CopyId, cancellationToken);
        if (copy is null)
            return ResponseHandler.NotFound("the copy of this reservation has been deleted");
        
        ReservationServices.Expire(reservation, copy);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success();
    }
}