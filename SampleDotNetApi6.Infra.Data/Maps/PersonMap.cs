using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleDotNetApi6.Domain.Entities;

namespace SampleDotNetApi6.Infra.Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("T_PERSON");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("IdPerson")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(p => p.Document)
                .HasColumnName("Document")
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasColumnName("Document")
                .IsRequired();

            builder.HasMany(p => p.Purchases)
                .WithOne(c => c.Person)
                .HasForeignKey(c => c.PersonId);
        }
    }
}
