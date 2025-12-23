namespace Core.Application.ApplicationServices.Copies.Commands.Borrow;

public sealed record MarkCopyAsBorrowedCommandRequest(
    long CopyId
) : ICommand;