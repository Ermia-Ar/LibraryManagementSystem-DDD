using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Books.Commands.RemoveGenre;

public sealed class RemoveGenreCommandHandle(
    IUnitOfWork unitOfWork
) : ICommandHandler<RemoveGenreCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(RemoveGenreCommandRequest request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Books.FindById(request.BookId, cancellationToken);
        
        if (book is null)
            return ResponseHandler.NotFound("Book not found");
        
        book.RemoveGenre(request.Genre);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ResponseHandler.Success(null);
    }
}