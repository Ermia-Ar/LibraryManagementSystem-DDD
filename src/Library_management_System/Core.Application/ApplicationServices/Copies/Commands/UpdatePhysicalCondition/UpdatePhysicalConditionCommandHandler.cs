namespace Core.Application.ApplicationServices.Copies.Commands.UpdatePhysicalCondition;

public sealed class UpdatePhysicalConditionCommandHandler(
    IUnitOfWork unitOfWork
) : ICommandHandler<UpdatePhysicalConditionCommandRequest>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<Response> Handle(UpdatePhysicalConditionCommandRequest request, CancellationToken cancellationToken)
    {
        var copy = await _unitOfWork.Copies.
            FindById(request.CopyId, cancellationToken); 
        if (copy is null)
            return ResponseHandler.NotFound("Copy not found");

        copy.UpdatePhysicalCondition(request.Condition);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResponseHandler.Success();
    }
}