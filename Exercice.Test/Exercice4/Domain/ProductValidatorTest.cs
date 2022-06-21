using Exercice.Exercice4.Domain.Entities;
using Exercice.Exercice4.Domain.Validations.Domain;
using FluentValidation.TestHelper;
using Xunit;

namespace Exercice.Test.Exercice4.Domain
{
    public class ProductValidatorTest
    {
        private readonly ProductValidator validator = new();

        [Fact]
        public void Name_Required()
        {
            Product product = new(string.Empty, 1);

            ExecuteAssert(ProductValidator.PRODUCT_NAME_REQUIRED, product);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void TestName(decimal price)
        {
            Product product = new("name", price);

            ExecuteAssert(ProductValidator.PRODUCT_PRICE_MUST_BE_GREATER_THAN_ZERO, product);
        }

        private void ExecuteAssert(string expectedMessage, Product product)
        {
            var result = validator.TestValidate(product);

            Assert.NotNull(result);
            Assert.NotNull(result.Errors);
            Assert.True(result.Errors.Count == 1);
            Assert.True(result.Errors.Any(it => it.ErrorMessage.Equals(expectedMessage, StringComparison.InvariantCultureIgnoreCase)));

        }
    }
}