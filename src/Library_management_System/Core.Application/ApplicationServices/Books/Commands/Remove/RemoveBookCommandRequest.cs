namespace Core.Application.ApplicationServices.Books.Commands.Remove;

public sealed record RemoveBookCommandRequest(
    long BookId
    ) : ICommand;