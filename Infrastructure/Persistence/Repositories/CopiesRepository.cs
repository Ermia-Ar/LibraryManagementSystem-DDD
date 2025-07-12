using Core.Application.ApplicationServices.Copies.Queries.GetAvailableCopies;
using Core.Domain.Aggregates.Copies;
using Core.Domain.Aggregates.Copies.Enums;
using Core.Domain.Aggregates.Copies.Repository;
using Core.Domain.Filtering;
using Infrastructure.Persistence.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Shared.Helper;

namespace Infrastructure.Persistence.Repositories;

public sealed class CopiesRepository(ApplicationContext context) : ICopiesRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<IReadOnlyList<IResponse>> GetAvailableCopies(GetAvailableCopiesFiltering filtering,
        CancellationToken token)
    {
        var copies = await _context.Copies.Where(x 
                => x.OperationalStatus == OperationalStatus.Available)
            .ToListAsync(token);
        var response = copies.Adapt<List<GetAvailableCopiesQueryResponse>>();
        
        return response;
    }


    public void Add(Copy copy)
    {
        _context.Copies.Add(copy);  
    }
}