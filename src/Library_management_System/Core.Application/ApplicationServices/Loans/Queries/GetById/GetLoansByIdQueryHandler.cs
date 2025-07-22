using Core.Domain.UnitOfWork;
using Mapster;
using Shared.Mediator.Query;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Loans.Queries.GetById;

public sealed class GetLoansByIdQueryHandler(
    IUnitOfWork unitOfWork
) : IQueryHandler<GetLoanByIdQueryRequest, GetLoanByIdQueryResponse>
{
    
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response<GetLoanByIdQueryResponse>> Handle(GetLoanByIdQueryRequest request, CancellationToken cancellationToken)
    {
        //check CheckOutId 
        var checkOut = await _unitOfWork.Loans
            .GetById(request.LoanId, cancellationToken);
        if (checkOut is null)
            return ResponseHandler.NotFound<GetLoanByIdQueryResponse>("Checked out not found");

        var response = checkOut.Adapt<GetLoanByIdQueryResponse>();
        return ResponseHandler.Success(response);
    }
}