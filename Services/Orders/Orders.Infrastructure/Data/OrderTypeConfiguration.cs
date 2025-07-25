using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Domain.Entities;

namespace Orders.Infrastructure.Data;

public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedDate).IsRequired();
        builder.Property(x => x.LastModifiedBy).IsRequired();
        builder.Property(x => x.LastModifiedDate).IsRequired();
        builder.Property(x => x.UserName).IsRequired();
        builder.Property(x => x.TotalPrice).IsRequired();
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.EmailAddress).IsRequired();
        builder.Property(x => x.AddressLine).IsRequired();
        builder.Property(x => x.Country).IsRequired();
        builder.Property(x => x.State).IsRequired();
        builder.Property(x => x.ZipCode).IsRequired();
        builder.Property(x => x.CardName).IsRequired();
        builder.Property(x => x.CardNumber).IsRequired();
        builder.Property(x => x.Expiration).IsRequired();
        builder.Property(x => x.Cvv).IsRequired();
        builder.Property(x => x.PaymentMethod).IsRequired();

        builder.HasKey(x => x.Id);
    }
}