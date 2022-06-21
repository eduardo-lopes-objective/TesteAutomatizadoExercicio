using Exercice.Exercice4.Domain.Entities;
using FluentValidation;

namespace Exercice.Exercice4.Domain.Validations.Domain
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public static string PRODUCT_NAME_REQUIRED = "Nome obrigatório";
        public static string PRODUCT_PRICE_MUST_BE_GREATER_THAN_ZERO = "Preço do produto deve ser maior que zero";

        public ProductValidator()
        {
            RuleFor(it => it.Name).NotEmpty().WithMessage(PRODUCT_NAME_REQUIRED);
            RuleFor(it => it.Price).GreaterThan(0).WithMessage(PRODUCT_PRICE_MUST_BE_GREATER_THAN_ZERO);
        }
    }
}