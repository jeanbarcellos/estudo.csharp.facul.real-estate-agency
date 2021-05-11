using RealEstateAgency.Domain.Entities.Validations;

namespace RealEstateAgency.Domain.Entities
{
    public class Apartment : Property
    {
        public static int MIN_NUMBER_OF_BEDROOMS = 1;
        public static int MIN_NUMBER_OF_BATHROMS = 1;

        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfGarage { get; set; }
        public bool HasElevator { get; set; }
        public int Floor { get; set; }
        public bool HasFurtine { get; private set; }
        public string Description { get; set; }

        // EF Rel.
        protected Apartment()
        {
        }

        public Apartment(
            int numberOfBedrooms,
            int numberOfBathrooms,
            int numberOfGarage,
            bool hasElevator,
            int floor,
            bool hasFurtine,
            string description,
            decimal saleValue,
            Client client
            ) : base(saleValue, client)
        {
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            NumberOfGarage = numberOfGarage;
            HasElevator = hasElevator;
            Floor = floor;
            HasFurtine = hasFurtine;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new ApartmentValidation().Validate(this);

            return ValidationResult.IsValid;
        }

    }
}
