using Core.Domain.Aggregates.Copies.Enums;
using Core.Domain.Aggregates.Copies.ValueObjects;
using Shared.Mediator.Command;

namespace Core.Application.ApplicationServices.Books.Commands.AddCopy;

public sealed record AddCopyCommandRequest(
    long BookId,
    Price Price,
    PhysicalCondition Condition
) : ICommand
{
    public static AddCopyCommandRequest Create(long bookId, AddCopyCommandRequestDto model)
        => new AddCopyCommandRequest(
            bookId,
            model.Price,
            model.Condition
        );
}

public sealed record AddCopyCommandRequestDto(
    Price Price,
    PhysicalCondition Condition
    );