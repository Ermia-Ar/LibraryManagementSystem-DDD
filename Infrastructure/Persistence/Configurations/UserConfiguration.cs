using Core.Domain.Aggregates.Users;
using Core.Domain.Aggregates.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property( x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Id,
                value => UserId.Create(value));
        
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
        
        builder.ComplexProperty(x => x.Sex, ab =>
        {
            ab.IsRequired();
        });
    }
}