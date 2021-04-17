namespace RealEstateAgency.Domain.Entities
{
    public class Apartment
    {
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfGarage { get; set; }
        public bool HasElevator { get; set; }
        public int Floor { get; set; }
    }
}
