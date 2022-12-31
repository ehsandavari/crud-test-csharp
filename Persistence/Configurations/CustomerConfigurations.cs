using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasIndex(customer => customer.Email).IsUnique();
        builder.Property(x => x.FirstName).HasColumnType("varchar").HasMaxLength(50);
        builder.Property(x => x.LastName).HasColumnType("varchar").HasMaxLength(50);
        builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(50);
        builder.HasIndex(customer => new
        {
            customer.FirstName,
            customer.LastName,
            customer.DateOfBirth
        }).IsUnique();
        builder.Property(x => x.BankAccountNumber).HasColumnType("varchar").HasMaxLength(50);

        builder.OwnsOne(x => x.PhoneNumber, sb =>
        {
            sb.Property(x => x.Prefix).HasMaxLength(5);
            sb.Property(x => x.Number).HasMaxLength(15);
        });
    }
}