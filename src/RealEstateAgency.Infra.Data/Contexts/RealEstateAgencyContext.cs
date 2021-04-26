using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Core.Data;
using RealEstateAgency.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Infra.Data.Contexts
{
    public class RealEstateAgencyContext : DbContext, IUnitOfWork
    {
        public DbSet<Client> Clients { get; set; }

        public RealEstateAgencyContext(DbContextOptions<RealEstateAgencyContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                x => x.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                // Por padrão todos os campos strings serão varchar(128)
                property.SetColumnType("varchar(128)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RealEstateAgencyContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
