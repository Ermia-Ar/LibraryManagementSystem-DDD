using System.Collections.Immutable;
using System.Data;
using Core.Application.ApplicationServices.Copies.Queries.GetAvailable;
using Core.Domain.Aggregates.Copies;
using Core.Domain.Aggregates.Copies.Repository;
using Core.Domain.Filtering;
using Dapper;
using Infrastructure.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shared.Helper;

namespace Infrastructure.Persistence.Repositories;

public sealed class CopiesRepository(
    ApplicationContext context
    ) : ICopiesRepository
{
    private readonly ApplicationContext _context = context;

    public Copy Add(Copy copy)
    {
        return _context.Copies.Add(copy).Entity;  
    }
    
    public void Remove(Copy copy)
    {
        _context.Copies.Remove(copy);
    }

    public async Task<IReadOnlyList<IResponse>> GetAvailable(GetAvailableCopiesFiltering filtering,
        CancellationToken token)
    {
        await using var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);
        await connection.OpenAsync(token);

        var parameters = new DynamicParameters();
        //filtering
        parameters.Add("Title", filtering.Title);
        parameters.Add("Author", filtering.Author);
        parameters.Add("PhysicalCondition", filtering.PhysicalCondition);
        parameters.Add("Price", filtering.Price);
        parameters.Add("Genre", filtering.Genre);
        

        var copies = await connection
            .QueryAsync<GetAvailableCopiesQueryResponse>(
            "SP_GetAvailableCopies", parameters, commandType: CommandType.StoredProcedure);

        return copies.ToImmutableList();
    }

    public async Task<Copy?> FindById(long id, CancellationToken token)
    {
        return await _context.Copies
            .FirstOrDefaultAsync(x => x.Id == id, token);
    }


}