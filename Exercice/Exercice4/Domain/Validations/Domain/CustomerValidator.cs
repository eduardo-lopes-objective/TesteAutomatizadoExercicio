using Exercice.Exercice4.Domain.Entities;
using FluentValidation;

namespace Exercice.Exercice4.Domain.Validations.Domain
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public static string CUSTOMER_NAME_REQUIRED = "Nome obrigatório";
        public static string CUSTOMER_CEP_REQUIRED = "CEP obrigatório";
        public static string CUSTOMER_CEP_INVALID_LENGTH = "CEP deve possuir 8 digitos";

        public CustomerValidator()
        {
            RuleFor(it => it.Name).NotEmpty().WithMessage(CustomerValidator.CUSTOMER_NAME_REQUIRED);

            RuleFor(it => it.DeliverCEP).Custom((value, context) =>
            {

                if (value == default(long) || value < 0)
                {
                    context.AddFailure(CustomerValidator.CUSTOMER_CEP_REQUIRED);

                    return;
                }

                if (value.ToString().Length != 8)
                {
                    context.AddFailure(CustomerValidator.CUSTOMER_CEP_INVALID_LENGTH);

                    return;
                }

            });
        }
    }
}