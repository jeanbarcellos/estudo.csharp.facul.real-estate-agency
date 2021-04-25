using FluentValidation;
using System;

namespace RealEstateAgency.Domain.Entities.Validations
{
    public class LandValidation : PropertyValidation<Land>
    {
        public static string OnACornerNotEmptyMessage = "Informação de o terreno é de esquina não informado";
        public static string WidthNotEmptyMessage = "Largura do terreno não informada";
        public static string HeightNotEmptyMessage = "Profundidade do terreno não informada";

        public LandValidation()
        {
            ValiateOnACorner();
            ValidateWidth();
            ValidateHeight();
            ValidateSaleValue();
            ValidateClient();
        }

        private void ValiateOnACorner()
        {
            RuleFor(o => o.OnACorner)
                .NotEmpty().WithMessage(OnACornerNotEmptyMessage);
        }

        private void ValidateWidth()
        {
            RuleFor(o => o.Width)
                .NotEmpty().WithMessage(WidthNotEmptyMessage);
        }

        private void ValidateHeight()
        {
            RuleFor(o => o.Height)
                .NotEmpty().WithMessage(HeightNotEmptyMessage);
        }
    }
}
