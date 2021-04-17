namespace RealEstateAgency.Domain.Entities
{
    public class House
    {
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfGarage { get; set; }
        public bool HasFurtine { get; set; }
        public string Description { get; set; }
    }
}
