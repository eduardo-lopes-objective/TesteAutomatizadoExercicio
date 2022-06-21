using Exercice.Exercice4.Domain.Entities;
using Exercice.Exercice4.Domain.Validations;
using Exercice.Exercice4.Domain.Validations.Domain;
using FluentValidation.TestHelper;
using Xunit;

namespace Exercice.Test.Exercice4.Domain
{
    public class ShoppingCartItemValidatorTest
    {
        private readonly ShoppingCartItemValidator validator = new();

        [Fact]
        public void Product_Required()
        {
            ShoppingCartItem shoppingCartItem = new(null, 10);

            ExecuteAssert(ShoppingCartItemValidator.PRODUCT_REQUIRED, shoppingCartItem);
        }

        [Fact]
        public void Product_Name_Required()
        {
            ShoppingCartItem shoppingCartItem = new(new Product(string.Empty, 25.60m), 10);

            ExecuteAssert(ProductValidator.PRODUCT_NAME_REQUIRED, shoppingCartItem);
        }

        [Fact]
        public void Product_Price_GreatherThanZero()
        {
            ShoppingCartItem shoppingCartItem = new(new Product("productName", 0), 10);

            ExecuteAssert(ProductValidator.PRODUCT_PRICE_MUST_BE_GREATER_THAN_ZERO, shoppingCartItem);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Amount_GreatherThanZero(int amount)
        {
            ShoppingCartItem shoppingCartItem = new(new Product("productName", 10), amount);

            ExecuteAssert(ShoppingCartItemValidator.PRODUCT_AMOUNT_MUST_BE_GREATER_THAN_ZERO, shoppingCartItem);
        }

        private void ExecuteAssert(string expectedMessage, ShoppingCartItem item)
        {
            var result = validator.TestValidate(item);

            Assert.NotNull(result);
            Assert.NotNull(result.Errors);
            Assert.True(result.Errors.Count == 1);
            Assert.True(result.Errors.Any(it => it.ErrorMessage.Equals(expectedMessage, StringComparison.InvariantCultureIgnoreCase)));

        }

    }
}