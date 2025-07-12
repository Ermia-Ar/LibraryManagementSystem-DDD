using Core.Domain.UnitOfWork;
using Mapster;
using Shared.Query;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Copies.Queries.GetAvailableCopies;

public sealed class GetAvailableCopiesQueryHandler(
    IUnitOfWork unitOfWork
    ) : IQueryHandler<GetAvailableCopiesQueryRequest, List<GetAvailableCopiesQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response<List<GetAvailableCopiesQueryResponse>>> Handle(GetAvailableCopiesQueryRequest request, CancellationToken cancellationToken)
    {
        var copies = await _unitOfWork
                .Copieses.GetAvailableCopies(request.Filtering, cancellationToken);

        var response = copies.Adapt<List<GetAvailableCopiesQueryResponse>>();
        
        return ResponseHandler.Success(response, "");
    }
}