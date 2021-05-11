using RealEstateAgency.Domain.Entities.Validations;

namespace RealEstateAgency.Domain.Entities
{
    public class House : Property
    {
        public static int MIN_NUMBER_OF_BEDROOMS = 1;
        public static int MIN_NUMBER_OF_BATHROMS = 1;

        public int NumberOfBedrooms { get; private set; }
        public int NumberOfBathrooms { get; private set; }
        public int NumberOfGarage { get; private set; }
        public bool HasFurtine { get; private set; }
        public string Description { get; set; }

        // EF Construct
        protected House()
        {

        }

        public House(
            int numberOfBedrooms,
            int numberOfBathrooms,
            int numberOfGarage,
            bool hasFurtine,
            string description,
            decimal saleValue,
            Client client
            ) : base(saleValue, client)
        {
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            NumberOfGarage = numberOfGarage;
            HasFurtine = hasFurtine;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new HouseValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
