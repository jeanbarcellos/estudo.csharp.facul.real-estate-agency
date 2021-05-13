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

            // TPH - Gerar uma estrutura de herança de entidade a partir de uma única tabela de banco de dados
            // TPC - Tabela por Classe Concreta - Todas as propriedades de uma classe, incluindo propriedades herdadas, são mapeadas para colunas da tabela correspondente
            // TPT - Tabela por tipo (uma tabela de banco de dados para cada classe de entidade)
            //
            // Os padrões de herança do TPC e do TPH geralmente oferecem melhor desempenho no Entity Framework que os padrões de herança do TPT,
            // pois os padrões de TPT podem resultar em consultas de junção complexas
            //
            // TPH é o padrão de herança padrão no Entity Framework

            builder.Property(o => o.SaleValue)
                .HasColumnName("sale_value")
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
