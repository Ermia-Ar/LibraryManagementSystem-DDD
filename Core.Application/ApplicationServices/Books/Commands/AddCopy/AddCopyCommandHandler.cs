using Core.Domain.Aggregates.Copies;
using Core.Domain.UnitOfWork;
using Shared.Mediator.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Books.Commands.AddCopy;

public sealed class AddCopyCommandHandler(
    IUnitOfWork unitOfWork) 
    : ICommandHandler<AddCopyCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response> Handle(AddCopyCommandRequest request, CancellationToken cancellationToken)
    {
        await using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var book = await _unitOfWork
                .Books.FindById(request.BookId, cancellationToken);
            if (book is null)
                return ResponseHandler.NotFound("Book not found");
        
            var copy = Copy.Create(request.BookId, request.Price, request.Condition);
            copy = _unitOfWork.Copies.Add(copy);
        
            await _unitOfWork.SaveChangesAsync(cancellationToken);
                
            book.AddCopyId(copy.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            await transaction.CommitAsync(cancellationToken);
            
            return ResponseHandler.Success("Copy Created");
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            return ResponseHandler.BadRequest(e.Message);
        }
    }
}