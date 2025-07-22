using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Copies.Commands.Remove;

public sealed class RemoveCopyCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<RemoveCopyCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(RemoveCopyCommandRequest request, CancellationToken cancellationToken)
    {
        var copy = await _unitOfWork.Copies
            .FindById(request.CopyId, cancellationToken);
        if (copy is null)
            return ResponseHandler.NotFound("Copy not found");
        
        var book = await _unitOfWork.Books
            .FindById(request.CopyId, cancellationToken);
        if (book is null)
            return ResponseHandler.NotFound("Book not found");
        
        book.RemoveCopyId(copy.Id);
        _unitOfWork.Copies.Remove(copy);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success();
    }
}