using Core.Domain.Aggregates.Copies;
using Core.Domain.Aggregates.Reservations;
using Core.Domain.Aggregates.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property(x => x.Id)
            .UseIdentityColumn(1000);
        
        builder.HasOne<Copy>()
            .WithOne()
            .HasForeignKey<Reservation>(x => x.CopyId);
        
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId);
        
        builder.ComplexProperty(x => x.ReservationDate, ab =>
        {
            ab.Property(x => x.Date)
                .IsRequired();
        });  
        

    }
}