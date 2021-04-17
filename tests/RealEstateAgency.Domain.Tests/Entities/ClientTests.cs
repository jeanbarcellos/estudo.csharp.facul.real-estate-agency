using Xunit;
using System;

namespace RealEstateAgency.Domain.Tests.Entities
{
    public class ClientTests
    {
        [Fact(DisplayName = "New client valid (simple)")]
        [Trait("Category", "Domain - Client")]
        public void Client_Create_ReturnClient()
        {
            // Arrange
            var socialNumber = "11122233389";
            var name = "Jean Barcellos";
            var birthday = new DateTime(1989, 12, 18);

            // Act
            var client = new Client(socialNumber, name, birthday);

            // Assert
            Assert.IsType<Client>(client);
            Assert.Equal(socialNumber, client.SocialNumber);
            Assert.Equal(name, client.Name);
            Assert.Equal(birthday, client.Birthday);
        }

        [Fact(DisplayName = "New client valid")]
        [Trait("Category", "Domain - Client")]
        public void Client_NewClient_ShouldBeValid()
        {
            // Arrange
            var socialNumber = "11122233389";
            var name = "Jean Barcellos";
            var birthday = new DateTime(1989, 12, 18);

            var client = new Client(socialNumber, name, birthday);

            // Act
            var result = client.IsValid();

            // Asssert
            Assert.True(result);
            Assert.Empty(client.ValidationResult.Errors);
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
            Assert.NotEmpty(client.ValidationResult.Errors);
        }
    }
}
