using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Books.Commands.Remove;

public sealed class RemoveBookCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<RemoveBookCommandRequest>
{
    
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(RemoveBookCommandRequest request, CancellationToken cancellationToken)
    {
        var book  = await _unitOfWork.Books.FindById(request.BookId, cancellationToken);
        
        if (book is null)
            return ResponseHandler.NotFound("Book not found");

        _unitOfWork.Books.Remove(book);
        
        //remove all copy for this book
        foreach (var bookCopyId in book.CopyIds)
        {
            var copy = await _unitOfWork.Copies
                .FindById(bookCopyId, cancellationToken);
            
            if (copy is not null)
                _unitOfWork.Copies.Remove(copy);
        }
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return ResponseHandler.Success();
    }
}