using Core.Domain.Aggregates.Users;

namespace Core.Application.ApplicationServices.Users.Commands.Add;

public sealed class AddUserCommandHandler(
    IUnitOfWork unitOfWork
    ): ICommandHandler<AddUserCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.Name, request.Gender,
            request.Address, request.Phone, request.Email);    
        
        _unitOfWork.Users.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return ResponseHandler.Success();
    }
}