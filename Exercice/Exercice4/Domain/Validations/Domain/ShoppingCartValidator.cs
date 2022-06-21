using Exercice.Exercice4.Domain.Entities;
using FluentValidation;

namespace Exercice.Exercice4.Domain.Validations.Domain
{
    public class ShoppingCartValidator : AbstractValidator<ShoppingCart>
    {
        public static string CUSTOMER_REQUIRED = "Cliente obrigatório";
        public static string PRODUCT_REQUIRED = "Produto obrigatório";

        public ShoppingCartValidator()
        {
            RuleFor(it => it.Customer).NotNull().WithMessage(CUSTOMER_REQUIRED)
                .DependentRules(() => RuleFor(it => it.Customer).SetValidator(new CustomerValidator()));

            RuleFor(it => it.ShoppingCartItemList).Custom((value, context) =>
            {
                if (value == null || value.Count == 0)
                {
                    context.AddFailure(PRODUCT_REQUIRED);

                    return;
                };
            });

            RuleForEach(it => it.ShoppingCartItemList)
            .SetValidator(new ShoppingCartItemValidator())
            .When(it => it.ShoppingCartItemList != null && it.ShoppingCartItemList.Count > 0);
        }
    }
}