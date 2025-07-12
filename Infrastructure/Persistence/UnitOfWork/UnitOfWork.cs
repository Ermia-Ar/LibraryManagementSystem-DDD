using Core.Domain.Aggregates.Books.Repository;
using Core.Domain.Aggregates.Circulates.Repository;
using Core.Domain.Aggregates.Copies.Repository;
using Core.Domain.Aggregates.Reservations.Repository;
using Core.Domain.Aggregates.Users.Repository;
using Core.Domain.UnitOfWork;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork(
	ApplicationContext context,
	IBooksRepository bookses,
	IUserRepository users,
	ICopiesRepository copieses,
	IReservationRepository reservations,
	ICirculatedRepository circulateds
	) : IUnitOfWork
{
	public IBooksRepository Bookses { get; } = bookses;

	public IUserRepository Users { get; } = users;

	public ICopiesRepository Copieses { get; } = copieses;

	public IReservationRepository Reservations { get; } = reservations;

	public ICirculatedRepository Circulateds { get; } = circulateds;

	public async Task SaveChangesAsync(CancellationToken cancellationToken)
	{
		await context.SaveChangesAsync(cancellationToken);
	}
}
