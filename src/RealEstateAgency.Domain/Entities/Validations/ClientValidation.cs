using FluentValidation;
using RealEstateAgency.Core.Validations;
using System;

namespace RealEstateAgency.Domain.Entities.Validations
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public static string NameNotEmptyMessage => "O nome não foi informado";
        public static string NameLengthMessage => "O nome deve ter entre 2 e 150 caracteres";
        public static string SocialNumberNotEmptyMessage => "O CPF não foi informado";
        public static string SocialNumberLengthMessage => "O CPF deve ter 14 caracteres";
        public static string SocialNumberInvalid => "O CPF é inválido";
        public static string BirthdayMustMessage => "O cliente deve ter 18 anos ou mais";

        public ClientValidation()
        {
            ValidateName();
            ValidateSocialNumber();
            ValidateBirthday();
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(NameNotEmptyMessage)
                .Length(2, 150).WithMessage(NameLengthMessage);
        }

        protected void ValidateSocialNumber()
        {
            RuleFor(c => c.SocialNumber)
                .NotEmpty().WithMessage(SocialNumberNotEmptyMessage)
                .Must(CpfIsValid).WithMessage(SocialNumberInvalid);
        }

        protected static bool HaveMinimumAge(DateTime birthDate) => birthDate <= DateTime.Now.AddYears(-18);

        protected void ValidateBirthday()
        {
            RuleFor(c => c.Birthday)
                .NotEmpty()
                .Must(HaveMinimumAge).WithMessage(BirthdayMustMessage);
        }

        protected static bool CpfIsValid(string socialNumber) => CpfValidator.IsValid(socialNumber);
    }
}
