using Exercice.Exercice4.Domain.Rrequests;
using Exercice.Exercice4.Domain.Validations.Domain;
using FluentValidation;

namespace Exercice.Exercice4.Domain.Validations.Requests
{
    public class CalculateTotalCommandValidator : AbstractValidator<CalculateTotalCommand>
    {
        public static string SHOPPING_CARD_REQUIRED = "Carrinho de compras obrigatório";

        public CalculateTotalCommandValidator()
        {
            RuleFor(it => it.ShoppingCart).NotNull().WithMessage(SHOPPING_CARD_REQUIRED)
            .DependentRules( () => RuleFor(it => it.ShoppingCart).SetValidator(new ShoppingCartValidator()));
        }
    }
}