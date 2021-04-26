using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Domain.Entities;

namespace RealEstateAgency.Infra.Data.Mappings
{
    public class ClientMapping : EntityMapping<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);

            builder.ToTable("client");

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.SocialNumber)
                .HasColumnName("social_number")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Birthday)
                .HasColumnName("birthday")
                .IsRequired();

        }
    }
}
