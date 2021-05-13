using RealEstateAgency.Core.Domain;
using System;

namespace RealEstateAgency.Domain.Entities
{
    public abstract class Property : Entity, IAggregateRoot
    {
        public static decimal NIM_SALE_VALUE = 9999.99m;

        public decimal SaleValue { get; private set; }
        public virtual Client Client { get; private set; }
        public Guid ClientId { get; private set; }

        // EF Contruct
        protected Property()
        { }

        public Property(decimal saleValue, Client client)
        {
            SaleValue = saleValue;
            Client = client;
        }
    }
}
