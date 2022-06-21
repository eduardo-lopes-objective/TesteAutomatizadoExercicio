using Exercice.Exercice4.Domain.Entities;
using Exercice.Exercice4.Domain.Rrequests;
using Exercice.Exercice4.Domain.Validations.Requests;
using Exercice.Exercice4.ExternalAPI;

namespace Exercice.Exercice4.Business
{
    public class ShoppingCartService
    {
        private readonly ICorreioAPI? CorreioAPI = null;

        public ShoppingCartService(ICorreioAPI correioAPI)
        {
            this.CorreioAPI = correioAPI;
        }

        public async Task<CalculateTotalResponse> CalculateTotal(CalculateTotalCommand request)
        {
            CalculateTotalResponse response = new();

            try
            {
                if (!IsValid(request, response))
                {
                    return response;
                }

                response.Total = ExecuteCalculateTotal(request.ShoppingCart);

                if (response.Total < 100)
                {
                    response.Total += await CalculateFrete(request.ShoppingCart.Customer);
                }

            }
            catch (Exception ex)
            {
                response.AddSystemError("Erro inexperado. Detalhes: " + ex.Message);

            }

            return response;
        }

        private bool IsValid(CalculateTotalCommand request, CalculateTotalResponse response)
        {
            CalculateTotalCommandValidator validator = new();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(error => response.AddBusinessError((error.ErrorMessage)));

                return false;
            }

            return true;
        }

        private decimal ExecuteCalculateTotal(ShoppingCart shoppingCart)
          => shoppingCart.ShoppingCartItemList.Sum(it => it.Amount * it.Product.Price);

        private async Task<decimal> CalculateFrete(Customer customer)
          => await CorreioAPI.CalculateFrete(customer.DeliverCEP);
    }
}