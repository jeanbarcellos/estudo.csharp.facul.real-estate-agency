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
    public class HouseRepository : IHouseRepository
    {
        protected readonly RealEstateAgencyContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public HouseRepository(RealEstateAgencyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<House>> GetAll()
        {
            return await _context.Houses
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<House> GetById(Guid id)
        {
            return await _context.Houses.FindAsync(id);
        }


        public Guid Insert(House house)
        {
            _context.Houses.Add(house);

            return house.Id;
        }

        public void Update(House house)
        {
            _context.Houses.Update(house);
        }

        public void Delete(House house)
        {
            _context.Houses.Remove(house);
        }

        public void Delete(Guid id)
        {
            //var house = _context.Houses.SingleOrDefaultAsync(s => s.Id == id);
            var house = _context.Houses.Find(id);

            if (house != null)
            {
                Delete(house);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Houses.AnyAsync(e => e.Id == id);
        }
    }
}
