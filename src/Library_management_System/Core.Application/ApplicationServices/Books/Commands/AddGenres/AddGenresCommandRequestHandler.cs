using Core.Domain.Aggregates.Books;
using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Books.Commands.AddGenres;

public sealed class AddGenresCommandRequestHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<AddGenresCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(AddGenresCommandRequest request, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Books.FindById(request.BookId, cancellationToken);
        
        if (book is null)
            return ResponseHandler.NotFound("Book not found");
        
        book.AddGenres(request.Genres);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success(null);
    }
}


