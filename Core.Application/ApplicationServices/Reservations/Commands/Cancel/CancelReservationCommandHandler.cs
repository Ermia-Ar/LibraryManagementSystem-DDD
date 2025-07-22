using Core.Domain.Services;
using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Reservations.Commands.Cancel;

public sealed class CancelReservationCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<CancelReservationCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(CancelReservationCommandRequest request, CancellationToken cancellationToken)
    {
        //check reservationId
        var reservation = await _unitOfWork.Reservations
            .FindById(request.ReservationId, cancellationToken);
        if (reservation is null)
            return ResponseHandler.NotFound("Reservation not found");
        //
        var copy = await _unitOfWork.Copies
            .FindById(reservation.CopyId, cancellationToken);
        if (copy is null)
            return ResponseHandler.NotFound("the copy of this reservation has been deleted");

        ReservationServices.Cancel(reservation, copy);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success();
    }
}