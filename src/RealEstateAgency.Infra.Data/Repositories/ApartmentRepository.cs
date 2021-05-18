using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Core.Data;
using RealEstateAgency.Domain.Entities;
using RealEstateAgency.Domain.Interfaces;
using RealEstateAgency.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Infra.Data.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        protected readonly RealEstateAgencyContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ApartmentRepository(RealEstateAgencyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Apartment>> GetAll()
        {
            return await _context.Apartments
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Apartment> GetById(Guid id)
        {
            return await _context.Apartments.FindAsync(id);
        }


        public Guid Insert(Apartment apartment)
        {
            _context.Apartments.Add(apartment);

            return apartment.Id;
        }

        public void Update(Apartment apartment)
        {
            _context.Apartments.Update(apartment);
        }

        public void Delete(Apartment apartment)
        {
            _context.Apartments.Remove(apartment);
        }

        public void Delete(Guid id)
        {
            //var apartment = _context.Apartments.SingleOrDefaultAsync(s => s.Id == id);
            var apartment = _context.Apartments.Find(id);

            if (apartment != null)
            {
                Delete(apartment);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Apartments.AnyAsync(e => e.Id == id);
        }
    }
}
