using RealEstateAgency.Core.Domain;
using RealEstateAgency.Domain.Validations;
using System;

namespace RealEstateAgency.Domain
{
    public class Client : Entity, IAggregateRoot
    {
        public string SocialNumber { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }

        public Client(string socialNumber, string name, DateTime birthday)
        {
            Id = Guid.NewGuid();
            SocialNumber = socialNumber;
            Name = name;
            Birthday = birthday;
        }

        public override bool IsValid()
        {
            ValidationResult = new ClientValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}