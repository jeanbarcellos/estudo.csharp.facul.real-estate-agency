using FluentValidation;
using System;

namespace RealEstateAgency.Domain.Validations
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public static string NameNotEmptyMessage => "Por favor, certifique-se de ter inserido o nome";
        public static string NameLengthMessage => "O nome deve ter entre 2 e 150 caracteres";
        public static string SocialNumberNotEmptyMessage => "Por favor, certifique-se de ter inserido o CPF";
        public static string SocialNumberLengthMessage => "O CPF deve ter 14 caracteres";
        public static string SocialNumberInvalid => "O CPF é inválido";
        public static string BirthdayMustMessage => "O cliente deve ter 18 anos ou mais";

        public ClientValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(NameNotEmptyMessage)
                .Length(2, 150).WithMessage(NameLengthMessage);

            RuleFor(c => c.SocialNumber)
                .NotEmpty().WithMessage(SocialNumberNotEmptyMessage)
                .Must(CpfIsValid).WithMessage(SocialNumberInvalid);

            RuleFor(c => c.Birthday)
                .NotEmpty()
                .Must(HaveMinimumAge).WithMessage(BirthdayMustMessage);
        }

        public static bool HaveMinimumAge(DateTime birthDate) => birthDate <= DateTime.Now.AddYears(-18);

        public static bool CpfIsValid(string socialNumber) => RealEstateAgency.Core.Validations.IsValidCpf(socialNumber);

    }

}
