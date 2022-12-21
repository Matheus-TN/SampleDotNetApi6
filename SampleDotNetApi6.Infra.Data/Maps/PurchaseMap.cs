using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleDotNetApi6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDotNetApi6.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("T_PURCHASE");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("IdPurchase")
                .IsRequired();

            builder.Property(p => p.ProductId)
                .HasColumnName("ProductId")
                .IsRequired();
            
            builder.Property(p => p.PersonId)
                .HasColumnName("PersonId")
                .IsRequired();

            builder.Property(p => p.Date)
                .HasColumnName("Date")
                .IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany(c => c.Purchases);

            builder.HasOne(p => p.Person)
                .WithMany(c => c.Purchases);
        }
    }
}
