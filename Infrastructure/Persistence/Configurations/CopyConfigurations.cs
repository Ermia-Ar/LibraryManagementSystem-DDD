using Core.Domain.Aggregates.Copies;
using Core.Domain.Aggregates.Copies.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CopyConfigurations : IEntityTypeConfiguration<Copy>
{
    public void Configure(EntityTypeBuilder<Copy> builder)
    {
        builder.Property( x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Id,
                value => CopyId.Create(value));

        builder.ComplexProperty(x => x.Price, ab =>
        {
            ab.ComplexProperty(x => x.Moeny, ab =>
            {
                ab.IsRequired();
            })
            .IsRequired();
        });

        builder.ComplexProperty(x => x.BookId, ab =>
        {
            ab.IsRequired();
        });

        builder.ComplexProperty(x => x.OperationalStatus, ab =>
        {

        });

        builder.ComplexProperty(x => x.PhysicalCondition, ab =>
        {
            ab.IsRequired();
        });
    }
}