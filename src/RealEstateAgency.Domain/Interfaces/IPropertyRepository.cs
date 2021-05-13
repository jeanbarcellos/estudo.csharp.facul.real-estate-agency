using RealEstateAgency.Core.Data;
using RealEstateAgency.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateAgency.Domain.Interfaces
{
    public interface IPropertyRepository : IRepository<Property>
    {
        Task<IEnumerable<Property>> GetAll();
        Task<Property> GetById(Guid id);
        Task<bool> Exists(Guid id);

        Guid Insert(Property property);
        void Update(Property property);
        void Delete(Property property);
        void Delete(Guid id);
    }
}
