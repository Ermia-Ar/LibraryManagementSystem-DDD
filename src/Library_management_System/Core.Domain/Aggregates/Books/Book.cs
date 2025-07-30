using Core.Domain.Aggregates.Books.Enums;
using Core.Domain.Aggregates.Books.Events;
using Core.Domain.Aggregates.Books.ValueObjects;
using Core.Domain.Exceptions;
using Shared.Domain;

namespace Core.Domain.Aggregates.Books;

public class Book : BaseAggregateRoot<long>
{
	private Book(Title title,
		Author author, PublicationDate date, Publisher publisher)
	{
		_genres = [];
		_copyIds = [];
		HandleEvent(
			new BookCreatedEvent(title.ToString(),
				  author.ToString(), publisher.ToString(), date.ToDateTime())
			);
	}

	public Title Title { get; protected set; } = null!;

	public Author Author { get; protected set; } = null!;

	public PublicationDate PublicationDate { get; protected set; } = null!;

	public Publisher Publisher { get; protected set; } = null!;
	

	private readonly List<Genre> _genres;
	public IReadOnlyList<Genre> Genres => [.. _genres];

	private readonly List<long> _copyIds;
	public IReadOnlyList<long> CopyIds => [.._copyIds];


	public static Book Create(Title title,
		Author author, PublicationDate publicationDate, Publisher publisher)
	{
		return new Book(title,
			author, publicationDate, publisher); 
	}
	
	public void AddGenres(List<Genre> genres)
	{
		foreach (Genre genre in genres)
		{
			if (_genres.Contains(genre))
			{
				throw new InvalidDateDomainException($"Genre {nameof(genres)} is already added");
			}
			HandleEvent(
				new GenreAddedEvent(
					Id,
					genre)
			);
		}
	}

	public void RemoveGenre(Genre genre)
	{
		HandleEvent(
			new RemovedGenreEvent(
				Id,
				genre)
			);
	}

	public void AddCopyId(long copyId)
	{
		HandleEvent(
			new CopyAddedEvent(
				copyId,
				Id
				)
			);
	}

	public void RemoveCopyId(long copyId)
	{
		if (!_copyIds.Contains(copyId))
			throw new InvalidDateDomainException($"Copy ID {copyId} does not exist");
		
		HandleEvent(
			new CopyRemovedEvent(
				copyId,
				Id
				)
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
			
			case CopyAddedEvent e:
				_copyIds.Add(e.CopyId);
				UpdatedDate = DateTime.Now;
				break;
			
			case CopyRemovedEvent e:	
				_copyIds.Remove(e.CopyId);
				UpdatedDate = DateTime.Now;
				break;

			default:
				throw new ArgumentOutOfRangeException(nameof(@event));
		}
	}
}