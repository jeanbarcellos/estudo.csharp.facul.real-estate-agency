using RealEstateAgency.Core.Data;
using RealEstateAgency.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(Guid id);

        void Insert(Client client);
        void Update(Client client);
        void Delete(Client client);
        void Delete(Guid id);
    }
}
