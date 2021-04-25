using Xunit;
using System;
using RealEstateAgency.Domain.Entities;
using RealEstateAgency.Domain.Entities.Validations;
using System.Linq;

namespace RealEstateAgency.Domain.Tests.Entities
{
    public class ClientTests
    {
        [Fact(DisplayName = "New client valid")]
        [Trait("Category", "Domain - Client")]
        public void Client_NewClient_ShouldBeValid()
        {
            // Arrange
            var socialNumber = "318.973.470-49";
            var name = "Jean Barcellos";
            var birthday = new DateTime(1989, 12, 18);

            var client = new Client(socialNumber, name, birthday);

            // Act
            var result = client.IsValid();

            // Asssert
            Assert.IsType<Client>(client);
            Assert.True(result);
            Assert.Empty(client.ValidationResult.Errors);
            Assert.Equal(socialNumber, client.SocialNumber);
            Assert.Equal(name, client.Name);
            Assert.Equal(birthday, client.Birthday);
        }

        [Fact(DisplayName = "New client invalid")]
        [Trait("Category", "Domain - Client")]
        public void Client_NewClient_ShouldBeInvalid()
        {
            // Arrange
            var socialNumber = "";
            var name = "";
            var birthday = DateTime.Now;

            var client = new Client(socialNumber, name, birthday);

            // Act
            var result = client.IsValid();

            // Asssert
            Assert.False(result);
            Assert.Equal(5, client.ValidationResult.Errors.Count);
            Assert.Contains(ClientValidation.NameNotEmptyMessage, client.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ClientValidation.NameLengthMessage, client.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ClientValidation.SocialNumberNotEmptyMessage, client.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ClientValidation.SocialNumberInvalid, client.ValidationResult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains(ClientValidation.BirthdayMustMessage, client.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }
    }
}
