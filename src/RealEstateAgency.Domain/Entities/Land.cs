namespace RealEstateAgency.Domain.Entities
{
    public class Land: Property
    {
        public bool OnACorner { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
    }
}
