using FluentValidation;

namespace RealEstateAgency.Domain.Entities.Validations
{
    public class HouseValidation : PropertyValidation<House>
    {
        public static string NumberOfBedroomsNotEmptyMessage = "Número de quartos não informado";
        public static string NumberOfBedroomsMinMessage = $"A quantidade mínima de quartos é {House.MIN_NUMBER_OF_BEDROOMS}.";
        public static string NumberOfBathroomsNotEmptyMessage = "Número de banheiros não informado";
        public static string NumberOfBathroomsMinMessage = $"A quantidade mínima de banheiros é {House.MIN_NUMBER_OF_BATHROMS}.";
        public static string DescriptionNotEmptyMessage = "A descrição deve ser informada";

        public HouseValidation()
        {
            ValidateNumberOfBedrooms();
            ValidateNumberOfBathrooms();
            ValidateNumberOfGarage();
            ValidateDescription();
            ValidateSaleValue();
            ValidateClient();
        }

        protected void ValidateNumberOfBedrooms()
        {
            RuleFor(o => o.NumberOfBedrooms)
                //.NotEmpty().WithMessage(NumberOfBedroomsNotEmptyMessage)
                .GreaterThanOrEqualTo(House.MIN_NUMBER_OF_BEDROOMS).WithMessage(NumberOfBedroomsMinMessage);
        }

        protected void ValidateNumberOfBathrooms()
        {
            RuleFor(o => o.NumberOfBathrooms)
                //.NotEmpty().WithMessage(NumberOfBathroomsNotEmptyMessage)
                .GreaterThanOrEqualTo(House.MIN_NUMBER_OF_BATHROMS).WithMessage(NumberOfBathroomsMinMessage);
        }

        protected void ValidateNumberOfGarage()
        { }

        protected void ValidateHasFurtine()
        { }

        protected void ValidateDescription()
        {
            RuleFor(o => o.Description)
                .NotEmpty().WithMessage(DescriptionNotEmptyMessage);
        }
    }
}
