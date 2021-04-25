using RealEstateAgency.Domain.Entities.Validations;

namespace RealEstateAgency.Domain.Entities
{
    public class Land : Property
    {
        public bool OnACorner { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public Land(bool onACorner, decimal width, decimal height, decimal saleValue, Client client) : base(saleValue, client)
        {
            OnACorner = onACorner;
            Width = width;
            Height = height;
        }

        public override bool IsValid()
        {
            ValidationResult = new LandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
