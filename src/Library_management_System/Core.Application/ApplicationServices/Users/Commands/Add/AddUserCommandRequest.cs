using Core.Domain.Aggregates.Users.Enums;

namespace Core.Application.ApplicationServices.Users.Commands.Add;

public sealed record AddUserCommandRequest(
    FullName Name,
    Sex Gender,
    Address Address,
    PhoneNumber Phone,
    Email Email
    ) : ICommand;