using Core.Domain.Filtering;
using Shared.Helper;

namespace Core.Domain.Aggregates.Reservations.Repository;

public interface IReservationRepository
{
    //Commands
    Reservation Add(Reservation reservation);
    
    //Queries 
    Task<Reservation?> FindByUserIdAndCopyId(long userId, long copyId,
        CancellationToken token);
    
    Task<Reservation?> FindById(long id, 
        CancellationToken token);
    
    Task<IResponse?> GetById(long id, 
        CancellationToken token);

    Task<IReadOnlyList<IResponse>> GetForUser(long userId,
        GetReservationFiltering filtering, CancellationToken token);
}