using Core.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork(
	ApplicationContext context,
	IBooksRepository books,
	IUsersRepository users,
	ICopiesRepository copies,
	IReservationRepository reservations, 
	ILoansRepository loan
	) : IUnitOfWork
{
	public IBooksRepository Books { get; } = books;

	public IUsersRepository Users { get; } = users;

	public ICopiesRepository Copies { get; } = copies;
	

	public IReservationRepository Reservations { get; } = reservations;
	

	public ILoansRepository Loans { get; } = loan;

	public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		await context.SaveChangesAsync(cancellationToken);
	}
	
	
	private IDbContextTransaction? _transaction;

	public async Task SaveChangeAsync(CancellationToken token = default)
	{
		await context.SaveChangesAsync(token);
	}

	public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken token = default)
	{
		if (_transaction is not null)
			throw new InvalidOperationException("An EF Core transaction is already in progress.");

		_transaction =  await context.Database.BeginTransactionAsync(token);
		return _transaction;
	}
	
	public async Task CommitTransactionAsync(CancellationToken token = default)
	{
		if (_transaction is null)
		{
			throw new InvalidOperationException("No EF Core transaction is in progress to commit.");
		}

		try
		{
			await _transaction.CommitAsync(token);
		}
		finally
		{
			await DisposeEfTransactionAsync();
		}
	}

	public async Task RollBackTransactionAsync(CancellationToken token = default)
	{
		if (_transaction == null)
		{
			throw new InvalidOperationException("No EF Core transaction is in progress to rollback.");
		}

		try
		{
			await _transaction.RollbackAsync(token);
		}
		finally
		{
			await DisposeEfTransactionAsync();
		}
	}

	private async Task DisposeEfTransactionAsync()
	{
		if (_transaction is not null)
		{
			await _transaction.DisposeAsync();
			_transaction = null;
		}
	}
	
	public void Dispose()
	{
		DisposeEfTransactionAsync().GetAwaiter().GetResult();
		context.Dispose();
	}
}
