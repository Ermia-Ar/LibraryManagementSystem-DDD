namespace Core.Application.ApplicationServices.Copies.Commands.Remove;

public sealed record RemoveCopyCommandRequest(
    long CopyId
    ) : ICommand;