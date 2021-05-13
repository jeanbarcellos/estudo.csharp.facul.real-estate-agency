using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Core.Data;
using RealEstateAgency.Domain.Entities;
using RealEstateAgency.Domain.Interfaces;
using RealEstateAgency.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Infra.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        protected readonly RealEstateAgencyContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public PropertyRepository(RealEstateAgencyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Property>> GetAll()
        {
            return await _context.Properties
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Property> GetById(Guid id)
        {
            return await _context.Properties.FindAsync(id);
        }


        public Guid Insert(Property property)
        {
            _context.Properties.Add(property);

            return property.Id;
        }

        public void Update(Property property)
        {
            _context.Properties.Update(property);
        }

        public void Delete(Property property)
        {
            _context.Properties.Remove(property);
        }

        public void Delete(Guid id)
        {
            //var property = _context.Properties.SingleOrDefaultAsync(s => s.Id == id);
            var property = _context.Properties.Find(id);

            if (property != null)
            {
                Delete(property);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Properties.AnyAsync(e => e.Id == id);
        }
    }
}
