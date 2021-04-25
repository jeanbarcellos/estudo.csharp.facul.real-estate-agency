using RealEstateAgency.Domain.Entities;
using RealEstateAgency.Domain.Entities.Validations;
using System;
using System.Linq;
using Xunit;

namespace RealEstateAgency.Domain.Tests.Entities
{
    public class LandTests
    {
        private Client _client;

        public LandTests()
        {
            _client = new Client("318.973.470-49", "Jean Barcellos", new DateTime(1989, 12, 18));
        }

        [Fact(DisplayName = "New land valid")]
        [Trait("Category", "Domain - Land")]
        public void Apartment_NewApartment_ShouldBeValid()
        {
            // Arrange
            var onACorner = true;
            var width = 75.00m;
            var height = 25.00m;
            var saleValue = 123456.99m;

            var land = new Land(onACorner, width, height, saleValue, _client);

            // Act
            var result = land.IsValid();

            // Assert
            Assert.True(result);
            Assert.Empty(land.ValidationResult.Errors);
        }

        [Fact(DisplayName = "New land invalid")]
        [Trait("Category", "Domain - Land")]
        public void Apartment_NewApartment_ShouldBeInvalid()
        {
            // Arrange
            var onACorner = true;
            var width = 75.00m;
            var height = 25.00m;
            var saleValue = Land.NIM_SALE_VALUE - 0.01m;

            var land = new Land(onACorner, width, height, saleValue, null);

            // Act
            var result = land.IsValid();

            // Assert
            Assert.False(result);
            Assert.Equal(2, land.ValidationResult.Errors.Count);
            Assert.Contains(LandValidation.SaleValueMinMessage, land.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(LandValidation.ClientNotEmptyMessage, land.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }
    }
}
