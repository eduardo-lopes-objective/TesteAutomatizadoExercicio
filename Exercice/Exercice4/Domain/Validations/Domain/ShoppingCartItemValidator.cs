using Exercice.Exercice4.Domain.Entities;
using FluentValidation;

namespace Exercice.Exercice4.Domain.Validations.Domain
{
    public class ShoppingCartItemValidator : AbstractValidator<ShoppingCartItem>
    {
        public static string PRODUCT_REQUIRED = "Produto obrigatório";
        public static string PRODUCT_AMOUNT_MUST_BE_GREATER_THAN_ZERO = "Quantidade de produto deve ser maior que zero";

        public ShoppingCartItemValidator()
        {
            RuleFor(it => it.Product).NotNull().WithMessage(PRODUCT_REQUIRED)
            .DependentRules(() => RuleFor(it => it.Product).SetValidator(new ProductValidator()));

            RuleFor(it => it.Amount).GreaterThan(0).WithMessage(PRODUCT_AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        }
    }
}