using Core.Domain.Aggregates.Books;
using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Books.Commands.Add;

public class AddBookCommandHandler(
    IUnitOfWork unitOfWork
    ) : ICommandHandler<AddBookCommandRequest> 
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response> Handle(AddBookCommandRequest request, CancellationToken cancellationToken)
    {
        var book = Book.Create(request.Title, 
            request.Author, request.Date, request.Publisher);
        
         _unitOfWork.Books.Add(book);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success("Book Created");
    }
}