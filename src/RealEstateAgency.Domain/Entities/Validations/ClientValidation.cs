using FluentValidation;
using System;

namespace RealEstateAgency.Domain.Validations
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o nome")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

            RuleFor(c => c.SocialNumber)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o CPF")
                .Length(11).WithMessage("O CPF deve ter 11 caracteres"); ;

            RuleFor(c => c.Birthday)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("O cliente deve ter 18 anos ou mais");
        }

        public static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }

}
