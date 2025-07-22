namespace Core.Domain.Aggregates.Users.Repository;

public interface IUsersRepository
{
    User Add(User user); 
    
    Task<User?> FindById(long userId,
        CancellationToken cancellationToken);
}