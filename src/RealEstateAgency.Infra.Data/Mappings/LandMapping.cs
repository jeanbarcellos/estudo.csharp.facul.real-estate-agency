using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Domain.Entities;

namespace RealEstateAgency.Infra.Data.Mappings
{
    public class LandMapping : IEntityTypeConfiguration<Land>
    {
        public void Configure(EntityTypeBuilder<Land> builder)
        {
            // builder.ToTable("land");

            builder.Property(o => o.OnACorner)
                .HasColumnName("on_a_corner")
                .IsRequired();

            builder.Property(o => o.Width)
                .HasColumnName("width")
                .IsRequired();

            builder.Property(o => o.Height)
                .HasColumnName("height")
                .IsRequired();
        }
    }
}
