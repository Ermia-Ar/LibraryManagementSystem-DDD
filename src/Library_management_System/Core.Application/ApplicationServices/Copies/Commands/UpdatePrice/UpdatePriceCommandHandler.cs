using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Copies.Commands.UpdatePrice;


public sealed class UpdatePriceCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<UpdatePriceCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(UpdatePriceCommandRequest request, CancellationToken cancellationToken)
    {
        var copy = await _unitOfWork.Copies.
            FindById(request.CopyId, cancellationToken); 
        if (copy is null)
            return ResponseHandler.NotFound("Copy not found");

        copy.UpdatePrice(request.Price);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success();
    }
}