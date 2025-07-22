using Core.Domain.Aggregates.Users;
using Core.Domain.Aggregates.Users.Repository;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UsersRepository(
    ApplicationContext context
    ) : IUsersRepository
{
    
    private readonly ApplicationContext _context = context;
    
    public User Add(User user)
    {
        return _context.Users.Add(user).Entity;
    }

    public async Task<User?> FindById(long userId, CancellationToken cancellationToken)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
    }
}