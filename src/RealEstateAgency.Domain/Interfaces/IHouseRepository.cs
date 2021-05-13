using RealEstateAgency.Core.Data;
using RealEstateAgency.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.Interfaces
{
    public interface IHouseRepository : IRepository<House>
    {
        Task<IEnumerable<House>> GetAll();
        Task<House> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Guid Insert(House house);
        void Update(House house);
        void Delete(House house);
        void Delete(Guid id);
    }
}
