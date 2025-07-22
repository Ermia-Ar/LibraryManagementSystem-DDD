using Core.Domain.Aggregates.Copies.ValueObjects;
using Shared.Mediator.Command;

namespace Core.Application.ApplicationServices.Copies.Commands.UpdatePrice;

public sealed record UpdatePriceCommandRequest(
    long CopyId,
    Price Price
) : ICommand
{
    public static UpdatePriceCommandRequest Create(long copyId, UpdatePriceCommandRequestDto model)
        => new UpdatePriceCommandRequest(
            copyId,
            model.Price
        );
}
    
public sealed record UpdatePriceCommandRequestDto(
    Price Price
);

    