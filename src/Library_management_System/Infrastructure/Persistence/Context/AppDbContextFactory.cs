using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LibraryManagementSystemDb;Integrated Security=True;Trust Server Certificate=True");
        
        return new ApplicationContext(optionsBuilder.Options);
    }
}