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
    public class ClientRepository : IClientRepository
    {
        protected readonly RealEstateAgencyContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ClientRepository(RealEstateAgencyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Client> GetById(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }


        public Guid Insert(Client client)
        {
            _context.Clients.Add(client);

            return client.Id;
        }

        public void Update(Client client)
        {
            _context.Clients.Update(client);
        }

        public void Delete(Client client)
        {
            _context.Clients.Remove(client);
        }

        public void Delete(Guid id)
        {
            //var client = _context.Clients.SingleOrDefaultAsync(s => s.Id == id);
            var client = _context.Clients.Find(id);

            if (client != null)
            {
                Delete(client);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Clients.AnyAsync(e => e.Id == id);
        }
    }
}
