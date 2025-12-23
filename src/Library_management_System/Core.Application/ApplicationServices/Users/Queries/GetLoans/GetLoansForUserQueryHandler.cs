namespace Core.Application.ApplicationServices.Users.Queries.GetLoans;

public sealed class GetLoansForUserQueryHandler(
    IUnitOfWork unitOfWork
) : IQueryHandler<GetLoansForUserQueryRequest, PaginatedResult<GetLoansForUserQueryResponse>>
{
    
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response<PaginatedResult<GetLoansForUserQueryResponse>>> Handle(GetLoansForUserQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .FindById(request.UserId, cancellationToken);
        if (user is null)
            return ResponseHandler.NotFound<PaginatedResult<GetLoansForUserQueryResponse>>("User not found");
        
        var loans = await _unitOfWork.Loans.GetForUser(user.Id, 
            request.Filtering, cancellationToken);

        var response = 
            loans.Adapt<List<GetLoansForUserQueryResponse>>().ToPaginatedList(request.PaginationFiltering);
        
        return ResponseHandler.Success(response);
    }
}