using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Domain.Entities;

namespace RealEstateAgency.Infra.Data.Mappings
{
    public class PropertyMapping : EntityMapping<Property>
    {
        public override void Configure(EntityTypeBuilder<Property> builder)
        {
            base.Configure(builder);

            builder.Property(o => o.SaleValue)
                .HasColumnName("sale_value")
                .HasColumnType("float")
                .IsRequired();

            builder.Property(o => o.ClientId)
                .HasColumnName("client_id")
                .IsRequired();

            builder.HasOne(o => o.Client)
                .WithMany(t => t.Properties)
                .HasForeignKey(t => t.ClientId)
                .HasConstraintName(GenerateForeignKeyName("client_id"));

            builder.HasIndex(o => o.ClientId)
                .HasDatabaseName(GenerateIndexName("client_id"));

            builder.HasDiscriminator<int>("discriminator")
                .HasValue<House>(1)
                .HasValue<Apartment>(2)
                .HasValue<Land>(3);

        }
    }
}
