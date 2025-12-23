namespace Core.Application.ApplicationServices.Users.Queries.GetReservations;

public sealed class GetReservationsForUserQueryHandler(
    IUnitOfWork unitOfWork
) : IQueryHandler<GetReservationsForUserQueryRequest, PaginatedResult<GetReservationsForUserQueryResponse>>
{
    
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response<PaginatedResult<GetReservationsForUserQueryResponse>>> Handle(GetReservationsForUserQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .FindById(request.UserId, cancellationToken);
        if (user is null)
            return ResponseHandler.NotFound<PaginatedResult<GetReservationsForUserQueryResponse>>("User not found");
        
        var reservations = await _unitOfWork.Reservations.GetForUser(user.Id, 
            request.Filtering, cancellationToken);

        var response = reservations
            .Adapt<List<GetReservationsForUserQueryResponse>>().ToPaginatedList(request.PaginationFiltering);
        return ResponseHandler.Success(response);
    }
}