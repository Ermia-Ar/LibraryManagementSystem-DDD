using Core.Domain.Aggregates.Users.Enums;
using Core.Domain.Aggregates.Users.ValueObjects;
using Shared.Command;

namespace Core.Application.ApplicationServices.Users.Commands.Add;

public sealed record AddUserCommandRequest(
    FullName Name,
    Sex Gender,
    Address Address,
    PhoneNumber Phone,
    Email Email
    ) : ICommand;