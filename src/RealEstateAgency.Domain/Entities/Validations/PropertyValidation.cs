using FluentValidation;

namespace RealEstateAgency.Domain.Entities.Validations
{
    public class PropertyValidation<T> : AbstractValidator<T> where T : Property
    {
        public static string SaleValueNotEmptyMessage = "O valor de venda deve ser informado";
        public static string SaleValueMinMessage = $"O valor de venda mínimo é {Property.NIM_SALE_VALUE}.";

        public static string ClientNotEmptyMessage = "O cliente deve ser informado";

        public void ValidateSaleValue()
        {
            RuleFor(o => o.SaleValue)
                .NotEmpty().WithMessage(SaleValueNotEmptyMessage)
                .GreaterThan(Property.NIM_SALE_VALUE).WithMessage(SaleValueMinMessage);
        }

        public void ValidateClient()
        {
            RuleFor(o => o.Client)
                .NotEmpty()
                .WithMessage(ClientNotEmptyMessage);
        }
    }
}
