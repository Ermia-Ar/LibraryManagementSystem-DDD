using Core.Domain.Services;
using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Users.Commands.AddLoan;

public sealed class AddLoansCommandRequestHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<AddLoansCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(AddLoansCommandRequest request, CancellationToken cancellationToken)
    {
        await using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            //check userId
            var user = await _unitOfWork.Users
                .FindById(request.UserId, cancellationToken);
            if (user == null)
                return ResponseHandler.NotFound("User not found");
            
            //check copyId
            var copy = await _unitOfWork.Copies
                .FindById(request.CopyId, cancellationToken);
            if (copy is null)
                return ResponseHandler.NotFound("Copy not found");
            
            //try to find a reservation for this user
            var reservation = await _unitOfWork.Reservations
                .FindByUserIdAndCopyId(request.UserId, request.CopyId, cancellationToken);
            
            var (loan, errorMessage) = LoanServices
                .CreateLoan(user, copy, request.DueDate, reservation);
            
            if (errorMessage != null)
                return ResponseHandler.BadRequest(errorMessage);
            
            //Add to loan Table
            loan = _unitOfWork.Loans.Add(loan);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            //add loan to user loans
            user.AddLoansId(loan.Id);
            
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