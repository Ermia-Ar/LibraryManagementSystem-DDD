namespace Core.Application.ApplicationServices.Copies.Queries.GetAvailable;

public sealed class GetAvailableCopiesQueryHandler(
    IUnitOfWork unitOfWork
    ) : IQueryHandler<GetAvailableCopiesQueryRequest, PaginatedResult<GetAvailableCopiesQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response<PaginatedResult<GetAvailableCopiesQueryResponse>>> Handle(GetAvailableCopiesQueryRequest request, CancellationToken cancellationToken)
    {
        var copies = await _unitOfWork
                .Copies.GetAvailable(request.Filtering, cancellationToken);
        
        var response = copies
            .Adapt<List<GetAvailableCopiesQueryResponse>>().ToPaginatedList(request.Pagination);
        
        return ResponseHandler.Success(response);
    }
}