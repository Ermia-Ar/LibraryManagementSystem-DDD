using System.Reflection;

namespace Infrastructure.Persistence.Context;

public class ApplicationContext(DbContextOptions<ApplicationContext> options)
    : DbContext(options)
{ 
    public DbSet<Book> Books { get; set; }
    public DbSet<Copy> Copies { get; set; }
    
    public DbSet<Reservation> Reservations { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Loan> CheckedOuts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasDefaultSchema("Library");
    }
}