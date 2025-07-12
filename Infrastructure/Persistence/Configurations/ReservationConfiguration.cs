using Core.Domain.Aggregates.Reservations.ValueObjects;
using Core.Domain.Aggregates.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property( x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Id,
                value => ReservationId.Create(value));

        builder.ComplexProperty(x => x.CopyId)
            .IsRequired();
        
        builder.ComplexProperty(x => x.UserId)
            .IsRequired();
        
        builder.ComplexProperty(x => x.ReservationDate, ab =>
        {
            ab.Property(x => x.Date)
                .IsRequired();
        });  
        
        builder.ComplexProperty(x => x.Status)
            .IsRequired();  

    }
}