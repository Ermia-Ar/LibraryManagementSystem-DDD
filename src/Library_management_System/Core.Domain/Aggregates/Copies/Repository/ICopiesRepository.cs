namespace Core.Domain.Aggregates.Copies.Repository;

public interface ICopiesRepository
{
    Copy Add(Copy copy);
    
    void Remove(Copy copy);
    
    Task<IReadOnlyList<IResponse>> GetAvailable(GetAvailableCopiesFiltering filtering,
        CancellationToken token);
    
    Task<Copy?> FindById(long id, CancellationToken token);
}
