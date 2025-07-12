using Core.Domain.Aggregates.Books;
using Core.Domain.Aggregates.Books.Enums;
using Core.Domain.Aggregates.Books.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Json;

namespace Infrastructure.Persistence.Configurations;

public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property( x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Id,
                value => BookId.Create(value));
        
        
        
        builder.ComplexProperty(x => x.Title, ab =>
        {
            ab.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(180);
        });

        builder.ComplexProperty(x => x.Author, ab =>
        {
            ab.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(180);
        });

        builder.ComplexProperty(x => x.Publisher, ab =>
        {
            ab.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(180);
        });
        
        builder.ComplexProperty(x => x.PublicationDate, ab =>
        {
            ab.Property(x => x.Date)
                .IsRequired();
        });

        
        builder.Property(x => x.Genres)
            .HasConversion(x => Json.Serialize(x)
                , ab => Json.Deserialize<List<Genre>>(ab));
    }
}