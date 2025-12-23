namespace Core.Application.ApplicationServices.Users.Commands.Update;

public sealed record UpdateUserInfoCommandRequest(
    long UserId,
    FullName FullName,
    Address Address,
    PhoneNumber PhoneNumber,
    Email Email
) : ICommand
{
    public static UpdateUserInfoCommandRequest Create(long id, UpdateUserInfoCommandRequestDto model)
        => new (
            id,
            model.FullName,
            model.Address,
            model.PhoneNumber,
            model.Email
        );
};

public sealed record UpdateUserInfoCommandRequestDto(
    FullName FullName,
    Address Address,
    PhoneNumber PhoneNumber,
    Email Email
);


