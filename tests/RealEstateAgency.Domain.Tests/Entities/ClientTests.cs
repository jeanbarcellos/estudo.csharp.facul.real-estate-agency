using Xunit;
using System;

namespace RealEstateAgency.Domain.Tests.Entities
{
    public class ClientTests
    {
        [Fact(DisplayName = "Create Client")]
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
    }
}
