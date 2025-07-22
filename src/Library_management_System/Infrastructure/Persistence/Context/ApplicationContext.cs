using System.Reflection;
using Core.Domain.Aggregates.Books;
using Core.Domain.Aggregates.Copies;
using Core.Domain.Aggregates.Loans;
using Core.Domain.Aggregates.Reservations;
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
    
    public DbSet<Loan> CheckedOuts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasDefaultSchema("Library");
    }
}