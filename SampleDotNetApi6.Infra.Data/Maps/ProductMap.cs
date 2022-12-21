using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleDotNetApi6.Domain.Entities;

namespace SampleDotNetApi6.Infra.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("T_PRODUCT");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("IdProduct")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(p => p.CodErp)
                .HasColumnName("CodErp")
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnName("Price")
                .IsRequired();

            builder.HasMany(p => p.Purchases)
                .WithOne(c => c.Product)
                .HasForeignKey(p => p.ProductId);
        }
    }
}
