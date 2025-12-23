namespace Core.Application.ApplicationServices.Reservations.Queries.GetById;

public sealed class GetReservationByIdQueryHandler(
    IUnitOfWork unitOfWork
) : IQueryHandler<GetReservationByIdQueryRequest, GetReservationByIdQueryResponse>
{
    
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response<GetReservationByIdQueryResponse>> Handle(GetReservationByIdQueryRequest request, CancellationToken cancellationToken)
    {
        //check reservationId
        var reservation = await _unitOfWork.Reservations
            .GetById(request.ReservationId, cancellationToken);
        if (reservation is null)
            return ResponseHandler.NotFound<GetReservationByIdQueryResponse>("Reservation not found");

        var response = reservation.Adapt<GetReservationByIdQueryResponse>();
        return ResponseHandler.Success(response);
    }
}