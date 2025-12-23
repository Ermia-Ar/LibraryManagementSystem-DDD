namespace Core.Domain.Aggregates.Loans.Repository;

public interface ILoansRepository
{
    //Commands
    Loan Add(Loan checkOut);
    
    //Queries

    Task<IReadOnlyList<IResponse>> GetForUser(long userId, GetLoansFiltering filtering,
        CancellationToken token = default);
    Task<IResponse?> GetById(long id, CancellationToken token);
    Task<Loan?> FindById(long id, CancellationToken cancellationToken);
}