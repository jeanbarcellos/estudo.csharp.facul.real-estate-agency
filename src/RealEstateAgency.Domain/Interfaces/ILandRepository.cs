using RealEstateAgency.Core.Data;
using RealEstateAgency.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.Interfaces
{
    public interface ILandRepository : IRepository<Land>
    {
        Task<IEnumerable<Land>> GetAll();
        Task<Land> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Guid Insert(Land land);
        void Update(Land land);
        void Delete(Land land);
        void Delete(Guid id);
    }
}
