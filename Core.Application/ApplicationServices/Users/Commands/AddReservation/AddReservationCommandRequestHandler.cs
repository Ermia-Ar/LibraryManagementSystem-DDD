using Core.Domain.Aggregates.Copies.Enums;
using Core.Domain.Aggregates.Reservations;
using Core.Domain.Aggregates.Reservations.ValueObjects;
using Core.Domain.Services;
using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Users.Commands.AddReservation;

public sealed class AddReservationCommandRequestHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<AddReservationCommandRequest>
{
    
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(AddReservationCommandRequest request, CancellationToken cancellationToken)
    {
        await using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            //check userId
            var user = await _unitOfWork.Users
                .FindById(request.UserId, cancellationToken);
            if (user is null)
                return ResponseHandler.NotFound("User not found");
            
            //check copyId
            var copy = await _unitOfWork.Copies
                .FindById(request.CopyId, cancellationToken);
            if (copy is null)
                return ResponseHandler.NotFound("Copy not found");

            var (reservation, errorMessage) = ReservationServices
                .CreateReservation(user, copy, request.ReservationDate);
            
            if (errorMessage is not null)
                return ResponseHandler.BadRequest(errorMessage);
            
            //add to reservation table
            reservation = _unitOfWork.Reservations.Add(reservation);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            //add reservationId to User reservations
            user.AddReservationId(reservation.Id);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            
            return ResponseHandler.Success();
        }
        catch (Exception e)
        {
            await _unitOfWork.RollBackTransactionAsync(cancellationToken);
            return ResponseHandler.BadRequest(e.Message);
        }
    }
}