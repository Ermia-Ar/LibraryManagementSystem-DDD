using Core.Domain.Aggregates.Books.Repository;
using Core.Domain.Aggregates.Circulates.Repository;
using Core.Domain.Aggregates.Copies.Repository;
using Core.Domain.Aggregates.Reservations.Repository;
using Core.Domain.Aggregates.Users.Repository;

namespace Core.Domain.UnitOfWork;

public interface IUnitOfWork
{
    IBooksRepository Bookses { get; }  
    IUserRepository Users { get; }
    ICopiesRepository Copieses { get; }
    IReservationRepository Reservations { get; }
    ICirculatedRepository Circulateds { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}