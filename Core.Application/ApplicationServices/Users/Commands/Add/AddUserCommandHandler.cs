using Core.Domain.Aggregates.Users;
using Core.Domain.Aggregates.Users.Repository;
using Core.Domain.Aggregates.Users.ValueObjects;
using Core.Domain.UnitOfWork;
using Shared.Command;
using Shared.Responses;

namespace Core.Application.ApplicationServices.Users.Commands.Add;

public sealed class AddUserCommandHandler(
    IUnitOfWork unitOfWork
    ): ICommandHandler<AddUserCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public Task<Response> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = User.Create(UserId.Create(Guid.NewGuid()), 
            request.Name, request.Gender, request.Address, request.Phone, request.Email);    
        
        _unitOfWork.Users.Add(user);
        return Task.FromResult(ResponseHandler.Success<User>("Created"));
    }
}