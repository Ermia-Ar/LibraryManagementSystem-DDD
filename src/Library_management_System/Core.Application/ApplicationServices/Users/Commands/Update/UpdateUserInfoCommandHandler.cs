namespace Core.Application.ApplicationServices.Users.Commands.Update;

public sealed class UpdateUserInfoCommandHandler(
    IUnitOfWork unitOfWork
    ) : ICommandHandler<UpdateUserInfoCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(UpdateUserInfoCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .FindById(request.UserId, cancellationToken);
        if (user is null)
            return ResponseHandler.NotFound("User not found");
        
        user.UpdateInfo(request.FullName, 
            request.PhoneNumber, request.Address, request.Email);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success();
    }
}