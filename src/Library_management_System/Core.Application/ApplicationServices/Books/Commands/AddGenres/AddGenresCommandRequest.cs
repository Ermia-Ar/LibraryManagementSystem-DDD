using Core.Domain.Aggregates.Books.Enums;
using Shared.Mediator.Command;

namespace Core.Application.ApplicationServices.Books.Commands.AddGenres;

public record AddGenresCommandRequest(
    long BookId,
    List<Genre> Genres
) : ICommand
{
    public static AddGenresCommandRequest Create(long id, AddGenresCommandRequestDto model)
        => new AddGenresCommandRequest(
            id,
            model.Genres
        );
}

public record AddGenresCommandRequestDto(
    List<Genre> Genres
);


