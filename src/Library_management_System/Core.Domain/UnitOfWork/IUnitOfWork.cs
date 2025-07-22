using Core.Domain.Aggregates.Books.Repository;
using Core.Domain.Aggregates.Copies.Repository;
using Core.Domain.Aggregates.Loans.Repository;
using Core.Domain.Aggregates.Reservations.Repository;
using Core.Domain.Aggregates.Users.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace Core.Domain.UnitOfWork;

public interface IUnitOfWork
{
    IBooksRepository Books { get; }  
    
    IUsersRepository Users { get; }
    
    ICopiesRepository Copies { get; }
    
    IReservationRepository Reservations { get; }
    
    ILoansRepository Loans { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken token = default);

    Task CommitTransactionAsync(CancellationToken token = default);

    Task RollBackTransactionAsync(CancellationToken token = default);

}