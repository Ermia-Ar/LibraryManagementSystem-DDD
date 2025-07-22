using Core.Domain.Services;
using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Loans.Commands.Return;

public sealed class ReturnLoanCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<ReturnLoanCommandRequest>
{
    
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(ReturnLoanCommandRequest request, CancellationToken cancellationToken)
    {
        //check loanId
        var loan = await _unitOfWork.Loans
            .FindById(request.LoanId, cancellationToken);
        if (loan == null)
            return ResponseHandler.NotFound("Loan not found");
      
        //Find Copy of this loan
        var copy = await _unitOfWork.Copies
            .FindById(loan.CopyId, cancellationToken);
        if (copy == null)
            return ResponseHandler.NotFound("Copy not found");

        var error =  LoanServices.Return(loan, copy);
        
        if (error is not null)
            return ResponseHandler.BadRequest(error);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success(meta:$"Fine Amount : {loan.FineAmount}");
    }
}