using RealEstateAgency.Core.Domain;
using RealEstateAgency.Domain.Validations;
using System;

namespace RealEstateAgency.Domain
{
    public class Client : Entity, IAggregateRoot
    {
        public string SocialNumber { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public Client(string socialNumber, string name, DateTime birthday)
        {
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
