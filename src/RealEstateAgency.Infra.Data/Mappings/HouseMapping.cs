using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Domain.Entities;

namespace RealEstateAgency.Infra.Data.Mappings
{
    public class HouseMapping : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            // builder.ToTable("house");

            builder.Property(o => o.NumberOfBedrooms)
                .HasColumnName("number_of_bedrooms")
                .IsRequired();

            builder.Property(o => o.NumberOfBathrooms)
                .HasColumnName("number_of_bathrooms")
                .IsRequired();

            builder.Property(o => o.NumberOfGarage)
                .HasColumnName("number_of_garage")
                .IsRequired();

            builder.Property(o => o.HasFurtine)
                .HasColumnName("has_furtine")
                .IsRequired();

            builder.Property(o => o.Description)
                .HasColumnName("description")
                .IsRequired();
        }
    }
}
