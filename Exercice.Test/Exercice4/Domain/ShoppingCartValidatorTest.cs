using Exercice.Exercice4.Domain.Entities;
using Exercice.Exercice4.Domain.Validations;
using Exercice.Exercice4.Domain.Validations.Domain;
using FluentValidation.TestHelper;
using Xunit;

namespace Exercice.Test.Exercice4.Domain
{
    public class ShoppingCartValidatorTest
    {
        private readonly ShoppingCartValidator validator = new();

        #region Customer Validation

        [Fact]
        public void Customer_Required()
        {
            List<ShoppingCartItem> shoppingCartItems = new(){
                new(new Product("product1", 10), 5)
            };

            ShoppingCart shoppingCart = new(null, shoppingCartItems);

            ExecuteAssert(ShoppingCartValidator.CUSTOMER_REQUIRED, shoppingCart);
        }

        [Fact]
        public void Customer_Name_Required()
        {
            List<ShoppingCartItem> shoppingCartItems = new(){
                new(new Product("product1", 10), 5)
            };

            ShoppingCart shoppingCart = new(new Customer(string.Empty, 12345678), shoppingCartItems);
            ExecuteAssert(CustomerValidator.CUSTOMER_NAME_REQUIRED, shoppingCart);
        }

        [Theory]
        [InlineData(123456)]
        [InlineData(123456789)]
        public void Customer_CEP_InvalidLength(long cep)
        {
            List<ShoppingCartItem> shoppingCartItems = new(){
                new(new Product("product1", 10), 5)
            };

            ShoppingCart shoppingCart = new(new Customer("CustomerName", cep), shoppingCartItems);

            ExecuteAssert(CustomerValidator.CUSTOMER_CEP_INVALID_LENGTH, shoppingCart);
        }

        #endregion

        private void ExecuteAssert(string expectedMessage, ShoppingCart item)
        {
            var result = validator.TestValidate(item);

            Assert.NotNull(result);
            Assert.NotNull(result.Errors);
            Assert.True(result.Errors.Count == 1);
            Assert.True(result.Errors.Any(it => it.ErrorMessage.Equals(expectedMessage, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}