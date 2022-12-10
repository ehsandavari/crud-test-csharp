using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasIndex(customer => customer.Email).IsUnique();

        builder.HasIndex(customer => new
        {
            customer.FirstName,
            customer.LastName,
            customer.DateOfBirth
        }).IsUnique();
    }
}