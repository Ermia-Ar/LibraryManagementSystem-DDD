using Core.Domain.Aggregates.Books.Enums;
using Core.Domain.Aggregates.Books.Events;
using Core.Domain.Aggregates.Books.ValueObjects;
using Core.Domain.Aggregates.Copies.Enums;
using Core.Domain.Aggregates.Copies.ValueObjects;
using Shared.Domain;

namespace Core.Domain.Aggregates.Books;

public class Book : BaseAggregateRoot<BookId>
{
	private Book()
	{
		_genres = [];
	}
	
	private Book(BookId id, Title title,
		Author author, PublicationDate date, Publisher publisher)
	{
		_genres = [];
		HandleEvent(
			new BookCreatedEvent(id.ToGuid(), Title.ToString(),
				  author.ToString(), publisher.ToString(), date.ToDateTime())
			);
	}

	public Title Title { get; protected set; } = null!;

	public Author Author { get; protected set; } = null!;

	public PublicationDate PublicationDate { get; protected set; } = null!;

	public Publisher Publisher { get; protected set; } = null!;

	private readonly List<Genre> _genres;
	public IReadOnlyList<Genre> Genres => [.. _genres];


	public static Book Create(BookId id, Title title,
		Author author, PublicationDate publicationDate, Publisher publisher)
	{
		return new Book(id, title,
			author, publicationDate, publisher); 
	}
	
	public void AddGenres(Genre genres)
	{
		if (_genres.Contains(genres))
		{
			throw new ArgumentException($"Genre {nameof(genres)} is already added");
		}
		HandleEvent(
			new GenreAddedEvent(
				Id.ToGuid(),
				genres)
			);
	}

	public void RemoveGenre(Genre genre)
	{
		HandleEvent(
			new RemovedGenreEvent(
				Id.ToGuid(),
				genre)
			);
	}


	protected override void ValidateInvariants()
	{

	}

	protected override void SetStateByEvent(IDomainEvent @event)
	{
		switch (@event)
		{

			case BookCreatedEvent e:
				Id = BookId.Create(e.BookId);
				Title = Title.Create(e.Title);
				Author = Author.Create(e.Author);
				Publisher = Publisher.Create(e.Publisher);
				PublicationDate = PublicationDate.Create(e.PublicationDate);
				CreatedDate = DateTime.Now;
				IsActive = true;
				break;

			case GenreAddedEvent e:
				_genres.Add(e.Genre);
				UpdatedDate = DateTime.Now;
				break;

			case RemovedGenreEvent e:
				_genres.Remove(e.Genre);
				UpdatedDate = DateTime.Now;
				break;

			default:
				throw new ArgumentOutOfRangeException(nameof(@event));
		}
	}
}