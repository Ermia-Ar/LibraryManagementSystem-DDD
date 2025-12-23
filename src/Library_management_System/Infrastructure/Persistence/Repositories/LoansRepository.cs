using Core.Application.ApplicationServices.Loans.Queries.GetById;
using Core.Application.ApplicationServices.Users.Queries.GetLoans;

namespace Infrastructure.Persistence.Repositories;

public class LoansRepository(
    ApplicationContext context
    ) : ILoansRepository
{
    
    private readonly ApplicationContext _context = context;
    
    public Loan Add(Loan checkOut)
    {
        return _context.CheckedOuts.Add(checkOut).Entity;
    }

    public async Task<IReadOnlyList<IResponse>> GetForUser(long userId, GetLoansFiltering filtering,
        CancellationToken token)
    {
        await using var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
        await connection.OpenAsync(token);

        var parameters = new DynamicParameters();
        
        parameters.Add("UserId", userId);
        //filtering
        parameters.Add("BookId", filtering.BookId);
        parameters.Add("DueDate", filtering.DueDate);
        parameters.Add("FineAmount", filtering.FineAmount);
        parameters.Add("BorrowDate", filtering.BorrowDate);
        parameters.Add("ReturnDate", filtering.ReturnDate);
        

        var loans = await connection
            .QueryAsync<GetLoansForUserQueryResponse>(
                "SP_GetLoansForUser", parameters, commandType: CommandType.StoredProcedure);

        return loans.ToImmutableList();
    }

    public async Task<IResponse?> GetById(long id, CancellationToken token)
    {
        await using var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
        await connection.OpenAsync(token);

        var parameters = new DynamicParameters();
        
        parameters.Add("LoanId", id);
        
        var loan = await connection
            .QueryFirstOrDefaultAsync<GetLoanByIdQueryResponse>(
                "SP_GetLoanById", parameters, commandType: CommandType.StoredProcedure);

        return loan;
    }

    public async Task<Loan?> FindById(long id, CancellationToken cancellationToken)
    {
        return await _context.CheckedOuts
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}