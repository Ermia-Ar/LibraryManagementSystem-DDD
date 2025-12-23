namespace Infrastructure.Persistence.Configurations;

public class CopyConfigurations : IEntityTypeConfiguration<Copy>
{
    public void Configure(EntityTypeBuilder<Copy> builder)
    {
        builder.Property(x => x.Id)
            .UseIdentityColumn(1000);

        builder.HasOne<Book>()
            .WithMany()
            .HasForeignKey(x => x.BookId);

        builder.ComplexProperty(x => x.Price, ab =>
        {
            ab.ComplexProperty(x => x.Moeny, ab =>
            {
                ab.IsRequired();
            })
            .IsRequired();
        });
        
    }
}