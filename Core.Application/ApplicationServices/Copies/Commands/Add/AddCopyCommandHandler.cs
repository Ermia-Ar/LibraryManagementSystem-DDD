using Core.Domain.Aggregates.Copies;
using Core.Domain.Aggregates.Copies.ValueObjects;
using Core.Domain.UnitOfWork;
using Shared.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Copies.Commands.Add;

public sealed class AddCopyCommandHandler(
    IUnitOfWork unitOfWork) 
    : ICommandHandler<AddCopyCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response> Handle(AddCopyCommandRequest request, CancellationToken cancellationToken)
    {
        var bookIsExist = await _unitOfWork
            .Bookses.BookIsExistedById(request.BookId, cancellationToken);
        
        var copy = Copy.Create(CopyId.Create(Guid.NewGuid()),
              request.BookId, request.Price, request.Condition);
        
        _unitOfWork.Copieses.Add(copy);
        return ResponseHandler.Success<Copy>("Created");
    }
}