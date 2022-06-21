using Exercice.Exercice4.Business;
using Exercice.Exercice4.Domain.Entities;
using Exercice.Exercice4.Domain.Rrequests;
using Exercice.Exercice4.Domain.Validations.Domain;
using Exercice.Exercice4.Domain.Validations.Requests;
using Exercice.Exercice4.ExternalAPI;
using Xunit;
using Moq;

namespace Exercice.Test.Exercice4.Business
{
    public class ShoppingCartServiceTest
    {
        private readonly ShoppingCartService shoppingCartService;
        private readonly Mock<ICorreioAPI> correioAPIMock;

        public ShoppingCartServiceTest()
        {
            correioAPIMock = new Mock<ICorreioAPI>();
            shoppingCartService = new(correioAPIMock.Object);
        }

        #region Shopping Cart Validation

        [Fact]
        public async Task ShoppingCart_Required()
        {
            CalculateTotalCommand request = new();

            var result = await shoppingCartService.CalculateTotal(request);

            Assert.NotNull(result);
            Assert.Equal(result.ResponseTypeEnum, ResponseTypeEnum.BusinessError);
            Assert.True(result.Messages.Count == 1);
            Assert.True(result.Messages.Any(it => it.Equals(CalculateTotalCommandValidator.SHOPPING_CARD_REQUIRED, StringComparison.CurrentCultureIgnoreCase)));
        }

        [Fact]
        public async Task ShoppingCard_Customer_Required()
        {
            List<ShoppingCartItem> shoppingCartItems = new(){
                new(new Product("productA", 10), 6)
            };

            CalculateTotalCommand request = new();

            request.ShoppingCart = new(null, shoppingCartItems);

            var result = await shoppingCartService.CalculateTotal(request);

            Assert.NotNull(result);
            Assert.Equal(result.ResponseTypeEnum, Exercice.Exercice4.Domain.Entities.ResponseTypeEnum.BusinessError);
            Assert.True(result.Messages.Count == 1);
            Assert.True(result.Messages.Any(it => it.Equals(ShoppingCartValidator.CUSTOMER_REQUIRED, StringComparison.CurrentCultureIgnoreCase)));
        }

        #endregion

        #region Calculation of total test

        [Fact]
        public async Task TotalMustBe38()
        {
            List<ShoppingCartItem> shoppingCartItems = new(){
                new(new Product("productA", 18), 2),
                new(new Product("productB", 1), 2)
            };

            CalculateTotalCommand request = new();

            request.ShoppingCart = new(new Customer("teste", 12345678), shoppingCartItems);

            var result = await shoppingCartService.CalculateTotal(request);

            Assert.NotNull(result);
            Assert.Equal(result.ResponseTypeEnum, ResponseTypeEnum.Sucess);
            Assert.True(result.Messages.Count == 0);
            Assert.Equal(38, result.Total);
        }

        [Fact]
        public async Task TotalMustBe38Dot5()
        {
            List<ShoppingCartItem> shoppingCartItems = new(){
                new(new Product("productA", 18), 2),
                new(new Product("productB", 1.25m), 2)
            };

            CalculateTotalCommand request = new();

            request.ShoppingCart = new(new Customer("teste", 12345678), shoppingCartItems);

            var result = await shoppingCartService.CalculateTotal(request);

            Assert.NotNull(result);
            Assert.Equal(result.ResponseTypeEnum, ResponseTypeEnum.Sucess);
            Assert.True(result.Messages.Count == 0);
            Assert.Equal(38.5m, result.Total);
        }

        [Fact]
        public async Task TotalMustBe138()
        {
            correioAPIMock.Setup(it => it.CalculateFrete(It.IsNotNull<long>())).Returns((long value) =>
            {
                return Task.FromResult(100);
            });

            List<ShoppingCartItem> shoppingCartItems = new(){
                new(new Product("productA", 18), 2),
                new(new Product("productB", 1), 2)
            };

            CalculateTotalCommand request = new();

            request.ShoppingCart = new(new Customer("teste", 12345678), shoppingCartItems);

            var result = await shoppingCartService.CalculateTotal(request);

            Assert.NotNull(result);
            Assert.Equal(result.ResponseTypeEnum, ResponseTypeEnum.Sucess);
            Assert.True(result.Messages.Count == 0);
            Assert.Equal(138, result.Total);
        }


        #endregion


    }
}