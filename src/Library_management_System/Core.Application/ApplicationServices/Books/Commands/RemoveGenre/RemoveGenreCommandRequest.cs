namespace Core.Application.ApplicationServices.Books.Commands.RemoveGenre;

public record RemoveGenreCommandRequest(
    long BookId,
    Genre Genre
) : ICommand
{
    public static RemoveGenreCommandRequest Create(long bookId, RemoveGenreCommandRequestDto model)
        => new RemoveGenreCommandRequest(
            bookId,
            model.Genre
        );
}
    
public record RemoveGenreCommandRequestDto(
    Genre Genre
);
    