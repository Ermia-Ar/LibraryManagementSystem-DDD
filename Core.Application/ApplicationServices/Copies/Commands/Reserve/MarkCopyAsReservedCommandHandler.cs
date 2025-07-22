using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Copies.Commands.Reserve;

public sealed class MarkCopyAsReservedCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<MarkCopyAsReservedCommandRequest>
{
    
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(MarkCopyAsReservedCommandRequest request, CancellationToken cancellationToken)
    {
        var copy = await _unitOfWork.Copies
            .FindById(request.CopyId, cancellationToken);
        
        if (copy is null)
            return ResponseHandler.NotFound("Copy not found");
        
        copy.MarkAsReserved();   
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success();
    }
}