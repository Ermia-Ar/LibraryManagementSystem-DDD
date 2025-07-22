using Core.Domain.Aggregates.Copies.Enums;
using Shared.Mediator.Command;

namespace Core.Application.ApplicationServices.Copies.Commands.UpdatePhysicalCondition;

public sealed record UpdatePhysicalConditionCommandRequest(
    long CopyId,
    PhysicalCondition Condition
) : ICommand
{
    public static UpdatePhysicalConditionCommandRequest Create(long copyId,
        UpdatePhysicalConditionCommandRequestDto model)
        => new UpdatePhysicalConditionCommandRequest(
            copyId,
            model.Condition
        );
}



public sealed record UpdatePhysicalConditionCommandRequestDto(
    PhysicalCondition Condition
);
    