using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Copies.Commands.Decommissioned;

public sealed class MarkCopyAsDecommissionedCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<MarkCopyAsDecommissionedCommandRequest>
{
    
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(MarkCopyAsDecommissionedCommandRequest request, CancellationToken cancellationToken)
    {
        var copy = await _unitOfWork.Copies
            .FindById(request.CopyId, cancellationToken);
        if (copy is null)
            return ResponseHandler.NotFound("Copy not found");
        
        copy.MarkAsDecommissioned();   
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success();
    }
}