using Xunit;
using System;
using RealEstateAgency.Domain.Entities;
using FluentAssertions;
using Xunit.Abstractions;
using RealEstateAgency.Domain.Entities.Validations;
using System.Linq;

namespace RealEstateAgency.Domain.Tests.Entities
{
    public class HouseTests
    {
        readonly ITestOutputHelper _outputHelper;
        private readonly Client _client;

        public HouseTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _client = new Client("318.973.470-49", "Jean Barcellos", new DateTime(1989, 12, 18));
        }


        [Fact(DisplayName = "New house valid")]
        [Trait("Category", "Domain - House")]
        public void House_NewHouse_ShouldBeValid()
        {
            // Arrange
            var numberOfBedrooms = 3;
            var numberOfBathrooms = 2;
            var numberOfGarage = 1;
            var hasFurtine = true;
            var saleValue = 123456.99m;
            var description = "Possui piscina";

            var house = new House(numberOfBedrooms, numberOfBathrooms, numberOfGarage, hasFurtine, saleValue, description, _client);

            // Act
            var result = house.IsValid();

            // Assert
            //Assert.True(result);
            //Assert.Empty(house.ValidationResult.Errors);

            // Assert
            result.Should().BeTrue();
            house.ValidationResult.Errors.Should().HaveCount(0, "must not contain validation errors.");
        }

        [Fact(DisplayName = "New house invalid")]
        [Trait("Category", "Domain - House")]
        public void House_NewHouse_ShouldBeInvalid()
        {
            // Arrange
            var numberOfBedrooms = House.MIN_NUMBER_OF_BEDROOMS - 1;
            var numberOfBathrooms = House.MIN_NUMBER_OF_BATHROMS - 1;
            var numberOfGarage = 0;
            var hasFurtine = true;
            var saleValue = Property.NIM_SALE_VALUE - 1;
            var description = "";

            var house = new House(numberOfBedrooms, numberOfBathrooms, numberOfGarage, hasFurtine, saleValue, description, null);

            // Act
            var result = house.IsValid();

            // Assert
            Assert.False(result);
            Assert.Equal(5, house.ValidationResult.Errors.Count);
            Assert.Contains(HouseValidation.NumberOfBedroomsMinMessage, house.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(HouseValidation.NumberOfBathroomsMinMessage, house.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(HouseValidation.DescriptionNotEmptyMessage, house.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(HouseValidation.SaleValueMinMessage, house.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(HouseValidation.ClientNotEmptyMessage, house.ValidationResult.Errors.Select(e => e.ErrorMessage));

            house.ValidationResult.Errors.Should().HaveCount(5, "must contain validation errors.");
            _outputHelper.WriteLine($"Foram encontrados {house.ValidationResult.Errors.Count} erros nesta validação");
        }
    }
}
