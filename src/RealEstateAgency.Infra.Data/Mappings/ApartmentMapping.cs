using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Domain.Entities;

namespace RealEstateAgency.Infra.Data.Mappings
{
    public class ApartmentMapping : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            // builder.ToTable("apartment");

            builder.Property(o => o.NumberOfBedrooms)
                .HasColumnName("number_of_bedrooms")
                .IsRequired();

            builder.Property(o => o.NumberOfBathrooms)
                .HasColumnName("number_of_bathrooms")
                .IsRequired();

            builder.Property(o => o.NumberOfGarage)
                .HasColumnName("number_of_garage")
                .IsRequired();

            builder.Property(o => o.HasElevator)
                .HasColumnName("has_elevator")
                .IsRequired();

            builder.Property(o => o.Floor)
                .HasColumnName("floor")
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
