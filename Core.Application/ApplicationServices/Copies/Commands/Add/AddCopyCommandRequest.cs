using Core.Domain.Aggregates.Books.ValueObjects;
using Core.Domain.Aggregates.Copies.Enums;
using Core.Domain.Aggregates.Copies.ValueObjects;
using Shared.Command;

namespace Core.Application.ApplicationServices.Copies.Commands.Add;

public sealed record AddCopyCommandRequest(
    BookId BookId,
    Price Price,
    PhysicalCondition Condition
    ) : ICommand;