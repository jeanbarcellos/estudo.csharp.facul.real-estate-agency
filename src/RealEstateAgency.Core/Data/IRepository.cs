
using RealEstateAgency.Core.Domain;
using System;

namespace RealEstateAgency.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
