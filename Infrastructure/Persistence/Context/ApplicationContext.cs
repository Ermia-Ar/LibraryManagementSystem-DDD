using System.Reflection;
using Core.Domain.Aggregates.Books;
using Core.Domain.Aggregates.Circulates;
using Core.Domain.Aggregates.Copies;
using Core.Domain.Aggregates.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class ApplicationContext(DbContextOptions<ApplicationContext> options)
    : DbContext(options)
{ 
    public DbSet<Book> Books { get; set; }
    public DbSet<Copy> Copies { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Circulate> Circulates { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}