using RealEstateAgency.Core.Data;
using RealEstateAgency.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.Interfaces
{
    public interface IApartmentRepository : IRepository<Apartment>
    {
        Task<IEnumerable<Apartment>> GetAll();
        Task<Apartment> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Guid Insert(Apartment apartment);
        void Update(Apartment apartment);
        void Delete(Apartment apartment);
        void Delete(Guid id);
    }
}
