using Core.Domain.Aggregates.Circulates;
using Core.Domain.Aggregates.Circulates.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CirculateConfiguration : IEntityTypeConfiguration<Circulate>
{
    public void Configure(EntityTypeBuilder<Circulate> builder)
    {
        builder.Property( x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Id,
                value => CirculatedId.Create(value));
        
        builder.ComplexProperty(x => x.CopyId)
            .IsRequired();
        
        builder.ComplexProperty(x => x.UserId)
            .IsRequired();

        builder.ComplexProperty(x => x.FineAmount, ab =>
        {
            ab.ComplexProperty(z => z.Money, ab =>
                {
                    ab.Property(x => x.Value)
                        .IsRequired();
                })
                .IsRequired();
        });
                
        builder.ComplexProperty(x => x.BorrowDate, ab =>
        {
            ab.Property(x => x.Date)
                .IsRequired();
        });  
        
        builder.ComplexProperty(x => x.ReturnDate, ab =>
        {
            ab.Property(x => x.Date)
                .IsRequired(false);
        });  
        
        builder.ComplexProperty(x => x.DueDate, ab =>
        {
            ab.Property(x => x.Date)
                .IsRequired();
        });  

        
    }
}