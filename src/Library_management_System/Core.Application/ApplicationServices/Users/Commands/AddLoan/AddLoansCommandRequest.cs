namespace Core.Application.ApplicationServices.Users.Commands.AddLoan;

public sealed record AddLoansCommandRequest(
    long UserId,
    long CopyId,
    DueDate DueDate
) : ICommand
{
    public static AddLoansCommandRequest Create(long userId, AddLoansCommandRequestDto model)
    => new AddLoansCommandRequest(userId, model.CopyId, model.DueDate);
}

public sealed record AddLoansCommandRequestDto(
    long CopyId,
    DueDate DueDate
    );