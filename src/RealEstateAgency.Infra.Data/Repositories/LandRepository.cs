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
    public class LandRepository : ILandRepository
    {
        protected readonly RealEstateAgencyContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public LandRepository(RealEstateAgencyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Land>> GetAll()
        {
            return await _context.Lands
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Land> GetById(Guid id)
        {
            return await _context.Lands.FindAsync(id);
        }


        public Guid Insert(Land land)
        {
            _context.Lands.Add(land);

            return land.Id;
        }

        public void Update(Land land)
        {
            _context.Lands.Update(land);
        }

        public void Delete(Land land)
        {
            _context.Lands.Remove(land);
        }

        public void Delete(Guid id)
        {
            //var land = _context.Lands.SingleOrDefaultAsync(s => s.Id == id);
            var land = _context.Lands.Find(id);

            if (land != null)
            {
                Delete(land);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Lands.AnyAsync(e => e.Id == id);
        }
    }
}
