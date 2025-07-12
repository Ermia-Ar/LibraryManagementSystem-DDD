using Core.Domain.Aggregates.Books;
using Core.Domain.Aggregates.Books.ValueObjects;
using Core.Domain.UnitOfWork;
using Shared.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Books.Commands.Add;

public class AddBookCommandHandler(
    IUnitOfWork unitOfWork
    ) : ICommandHandler<AddBookCommandRequest> 
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public Task<Response> Handle(AddBookCommandRequest request, CancellationToken cancellationToken)
    {
        var book = Book.Create(BookId.Create(Guid.NewGuid()), request.Title, 
            request.Author, request.Date, request.Publisher);
        
         _unitOfWork.Bookses.Add(book);
         return Task.FromResult(ResponseHandler.Success<Book>("Created"));
    }
}