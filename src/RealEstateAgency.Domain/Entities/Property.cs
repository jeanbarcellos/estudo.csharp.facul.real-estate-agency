using RealEstateAgency.Core.Domain;

namespace RealEstateAgency.Domain.Entities
{
    public abstract class Property : Entity
    {
        public decimal SaleValue { get; set; }
        public Client Client { get; set; }
    }
}
