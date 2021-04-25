using RealEstateAgency.Domain.Entities;
using RealEstateAgency.Domain.Entities.Validations;
using System;
using System.Linq;
using Xunit;

namespace RealEstateAgency.Domain.Tests.Entities
{
    public class ApartmentTests
    {
        private Client _client;

        public ApartmentTests()
        {
            _client = new Client("318.973.470-49", "Jean Barcellos", new DateTime(1989, 12, 18));
        }

        [Fact(DisplayName = "New apartment valid")]
        [Trait("Category", "Domain - Apartment")]
        public void Apartment_NewApartment_ShouldBeValid()
        {
            // Arrange
            var numberOfBedrooms = Apartment.MIN_NUMBER_OF_BEDROOMS + 1;
            var numberOfBathrooms = Apartment.MIN_NUMBER_OF_BATHROMS + 1;
            var numberOfGarage = 1;
            var hasElevator = true;
            var floor = 7;
            var hasFurtine = true;
            var saleValue = 123456.99m;
            var description = "Possui piscina";

            var apartment = new Apartment(numberOfBedrooms, numberOfBathrooms, numberOfGarage, hasElevator, floor, hasFurtine, description, saleValue, _client);

            // Act
            var result = apartment.IsValid();

            // Assert
            Assert.True(result);
            Assert.Empty(apartment.ValidationResult.Errors);
        }

        [Fact(DisplayName = "New apartment valid")]
        [Trait("Category", "Domain - Apartment")]
        public void Apartment_NewApartment_ShouldBeInvalid()
        {
            // Arrange
            var numberOfBedrooms = Apartment.MIN_NUMBER_OF_BEDROOMS - 1;
            var numberOfBathrooms = Apartment.MIN_NUMBER_OF_BATHROMS -1;
            var numberOfGarage = 1;
            var hasElevator = true;
            var floor = 0;
            var hasFurtine = true;
            var saleValue = Apartment.NIM_SALE_VALUE - 1;
            var description = "";

            var apartment = new Apartment(numberOfBedrooms, numberOfBathrooms, numberOfGarage, hasElevator, floor, hasFurtine, description, saleValue, null);

            // Act
            var result = apartment.IsValid();

            // Assert
            Assert.False(result);
            Assert.Equal(7, apartment.ValidationResult.Errors.Count);
            Assert.Contains(ApartmentValidation.NumberOfBedroomsMinMessage, apartment.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ApartmentValidation.NumberOfBathroomsMinMessage, apartment.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ApartmentValidation.DescriptionNotEmptyMessage, apartment.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ApartmentValidation.FloorNotEmptyMessage, apartment.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ApartmentValidation.FloorGreaterThanMessage, apartment.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ApartmentValidation.SaleValueMinMessage, apartment.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ApartmentValidation.ClientNotEmptyMessage, apartment.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

    }
}
