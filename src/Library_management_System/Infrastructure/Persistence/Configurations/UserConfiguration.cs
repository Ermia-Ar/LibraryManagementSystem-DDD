using Core.Domain.Aggregates.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Json;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id)
            .UseIdentityColumn(100000);
        
        
        builder.ComplexProperty(x => x.Name, ab =>
        {
            ab.Property(x => x.Name)
                .HasMaxLength(180)
                .IsRequired();
        }); 
        
        builder.ComplexProperty(x => x.Address, ab =>
        {
            ab.Property(x => x.Street)
                .HasMaxLength(100)
                .IsRequired();
            
            ab.Property(x => x.City)
                .HasMaxLength(100)
                .IsRequired();
            
            ab.Property(x => x.Country)
                .HasMaxLength(100)
                .IsRequired();
            
            ab.Property(x => x.PostalCode)
                .HasMaxLength(100)
                .IsRequired();
            
        });
        
        builder.ComplexProperty(x => x.Email, ab =>
        {
            ab.Property(x => x.Value)
                .HasMaxLength(250)
                .IsRequired();
        });  
        
        builder.ComplexProperty(x => x.PhoneNumber, ab =>
        {
            ab.Property(x => x.Number)
                .HasMaxLength(15)
                .IsRequired();
        });
        
        builder.Property(x => x.ReservationIds)
            .HasConversion(x => Json.Serialize(x),
                ab => Json.Deserialize<List<long>>(ab));
        
        builder.Property(x => x.LoanIds)
            .HasConversion(x => Json.Serialize(x),
                ab => Json.Deserialize<List<long>>(ab));
    }
}