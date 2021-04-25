using RealEstateAgency.Core.Domain;
using System;

namespace RealEstateAgency.Domain.Entities
{
    public abstract class Property : Entity
    {
        public static decimal NIM_SALE_VALUE = 9999.99m;

        public decimal SaleValue { get; set; }
        public Client Client { get; set; }

        protected Property()
        { }

        public Property(decimal saleValue, Client client)
        {
            SaleValue = saleValue;
            Client = client;
        }
    }
}
