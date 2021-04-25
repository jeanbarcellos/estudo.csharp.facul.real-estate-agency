using FluentValidation;
using System;

namespace RealEstateAgency.Domain.Entities.Validations
{
    public class ApartmentValidation : PropertyValidation<Apartment>
    {
        public static string NumberOfBedroomsNotEmptyMessage = "Número de quartos não informado";
        public static string NumberOfBedroomsMinMessage = $"A quantidade mínima de quartos é {Apartment.MIN_NUMBER_OF_BEDROOMS}.";
        public static string NumberOfBathroomsNotEmptyMessage = "Número de banheiros não informado";
        public static string NumberOfBathroomsMinMessage = $"A quantidade mínima de banheiros é {Apartment.MIN_NUMBER_OF_BATHROMS}.";
        public static string FloorNotEmptyMessage = "Andar não informado";
        public static string FloorGreaterThanMessage = "O andar mínimo é 1";
        public static string DescriptionNotEmptyMessage = "A descrição deve ser informada";

        public ApartmentValidation()
        {
            ValidateNumberOfBedrooms();
            ValidateNumberOfBathrooms();
            ValidateNumberOfGarage();
            ValidateHasElevator();
            ValidateFloor();
            ValidateHasFurtine();
            ValidateDescription();
            ValidateSaleValue();
            ValidateClient();
        }

        protected void ValidateNumberOfBedrooms()
        {
            RuleFor(o => o.NumberOfBedrooms)
                //.NotEmpty().WithMessage(NumberOfBedroomsNotEmptyMessage)
                .GreaterThanOrEqualTo(Apartment.MIN_NUMBER_OF_BEDROOMS).WithMessage(NumberOfBedroomsMinMessage);
        }

        protected void ValidateNumberOfBathrooms()
        {
            RuleFor(o => o.NumberOfBathrooms)
                //.NotEmpty().WithMessage(NumberOfBathroomsNotEmptyMessage)
                .GreaterThanOrEqualTo(Apartment.MIN_NUMBER_OF_BATHROMS).WithMessage(NumberOfBathroomsMinMessage);
        }

        protected void ValidateNumberOfGarage()
        { }

        protected void ValidateHasElevator()
        {

        }

        protected void ValidateFloor()
        {
            RuleFor(o => o.Floor)
                .NotEmpty().WithMessage(FloorNotEmptyMessage)
                .GreaterThan(0).WithMessage(FloorGreaterThanMessage);
        }

        protected void ValidateHasFurtine()
        { }

        protected void ValidateDescription()
        {
            RuleFor(o => o.Description)
                .NotEmpty().WithMessage(DescriptionNotEmptyMessage);
        }
    }
}
