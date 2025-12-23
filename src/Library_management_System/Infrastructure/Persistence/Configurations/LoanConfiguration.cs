namespace Infrastructure.Persistence.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loans");
        
        builder.Property(x => x.Id)
            .UseIdentityColumn(1000);

        builder.HasOne<Copy>()
            .WithOne()
            .HasForeignKey<Loan>(x => x.CopyId);
        
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder.ComplexProperty(x => x.FineAmount, ab =>
        {
            ab.ComplexProperty(z => z.Money, dh =>
                {
                    dh.Property(x => x.Value)
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