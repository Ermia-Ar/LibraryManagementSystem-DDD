using Core.Domain.Filtering;
using Shared.Helper;

namespace Core.Domain.Aggregates.Copies.Repository;

public interface ICopiesRepository
{
    public Task<IReadOnlyList<IResponse>> GetAvailableCopies(GetAvailableCopiesFiltering filtering,
        CancellationToken token);
    void Add(Copy copy);
}