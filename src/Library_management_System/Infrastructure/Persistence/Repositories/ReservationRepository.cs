using Core.Application.ApplicationServices.Reservations.Queries.GetById;
using Core.Application.ApplicationServices.Users.Queries.GetReservations;

namespace Infrastructure.Persistence.Repositories;

public class ReservationRepository(
    ApplicationContext context
    ) : IReservationRepository
{
    
    private readonly ApplicationContext _context = context;
    
    public Reservation Add(Reservation reservation)
    {
        return _context.Reservations.Add(reservation).Entity;
    }

    public async Task<Reservation?> FindByUserIdAndCopyId(long userId, long copyId, CancellationToken token)
    {
        return await _context.Reservations
            .FirstOrDefaultAsync(x => x.UserId == userId && x.CopyId == copyId, token);
    }

    public async Task<Reservation?> FindById(long id, CancellationToken token)
    {
        return await _context.Reservations
            .FirstOrDefaultAsync(x => x.Id == id, token);
    }

    public async Task<IResponse?> GetById(long id, CancellationToken token)
    {
        await using var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
        await connection.OpenAsync(token);

        var parameters = new DynamicParameters();
        
        parameters.Add("ReservationId", id);        

        var reservation = await connection
            .QueryFirstOrDefaultAsync<GetReservationByIdQueryResponse>(
                "SP_GetReservationById", parameters, commandType: CommandType.StoredProcedure);

        return reservation;
    }

    public async Task<IReadOnlyList<IResponse>> GetForUser(long userId, GetReservationFiltering filtering, CancellationToken token)
    {
        await using var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
        await connection.OpenAsync(token);

        var parameters = new DynamicParameters();
        
        parameters.Add("UserId", userId);
        //filtering
        parameters.Add("BookId", filtering.BookId);
        parameters.Add("Status", filtering.Status);
        parameters.Add("ReservationDate", filtering.ReservationDate);
        

        var reservations = await connection
            .QueryAsync<GetReservationsForUserQueryResponse>(
                "SP_GetReservationsForUser", parameters, commandType: CommandType.StoredProcedure);

        return reservations.ToImmutableList();
    }
}