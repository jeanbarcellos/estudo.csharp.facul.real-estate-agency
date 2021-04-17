using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(Guid id);

        bool Insert(Client client);
        bool Update(Client client);
        bool Delete(Client client);
        bool Delete(Guid id);
    }
}
