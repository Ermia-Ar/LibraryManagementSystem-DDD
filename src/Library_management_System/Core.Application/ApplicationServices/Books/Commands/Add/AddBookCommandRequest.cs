namespace Core.Application.ApplicationServices.Books.Commands.Add;

public sealed record AddBookCommandRequest(
    Title Title,
    Author Author,
    PublicationDate Date,
    Publisher Publisher,
    List<Genre> Genres
    
    ) : ICommand;