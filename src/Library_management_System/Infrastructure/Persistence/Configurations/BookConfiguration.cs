using Core.Domain.Aggregates.Books.Enums;

namespace Infrastructure.Persistence.Configurations;

public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(x => x.Id)
            .UseIdentityColumn(1000);
        
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
            .HasConversion(x => Json.Serialize(x),
                ab => Json.Deserialize<List<Genre>>(ab));
        
        builder.Property(x => x.CopyIds)
            .HasConversion(x => Json.Serialize(x), 
                ab => Json.Deserialize<List<long>>(ab));
    }
}