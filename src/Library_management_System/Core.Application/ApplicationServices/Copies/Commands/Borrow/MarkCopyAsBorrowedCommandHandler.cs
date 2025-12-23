namespace Core.Application.ApplicationServices.Copies.Commands.Borrow;

public sealed class MarkCopyAsBorrowedCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<MarkCopyAsBorrowedCommandRequest>
{
    
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(MarkCopyAsBorrowedCommandRequest request, CancellationToken cancellationToken)
    {
        var copy = await _unitOfWork.Copies
            .FindById(request.CopyId, cancellationToken);
        if (copy is null)
            return ResponseHandler.NotFound("Copy not found");
        
        copy.MarkAsBorrowed();   
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success();
    }
}