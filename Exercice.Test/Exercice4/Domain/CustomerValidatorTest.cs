using Exercice.Exercice4.Domain.Entities;
using Exercice.Exercice4.Domain.Validations.Domain;
using FluentValidation.TestHelper;
using Xunit;

namespace Exercice.Test.Exercice4.Domain
{
    public class CustomerValidatorTest
    {
        private readonly CustomerValidator customerValidator = new();

        [Fact]
        public void NameRequired()
        {
            Customer customer = new(string.Empty, 12345678);

            ExecuteAssert(CustomerValidator.CUSTOMER_NAME_REQUIRED, customer);
        }

        [Fact]
        public void CEPRequired()
        {
            Customer customer = new("customername", 0);

            ExecuteAssert(CustomerValidator.CUSTOMER_CEP_REQUIRED, customer);
        }

        [Theory]
        [InlineData(123456)]
        [InlineData(12345678910)]
        public void CEP_InvalidLength(long cep)
        {
            Customer customer = new("customername", cep);

            ExecuteAssert(CustomerValidator.CUSTOMER_CEP_INVALID_LENGTH, customer);
        }

        private void ExecuteAssert(string expectedMessage, Customer customer)
        {
            var result = customerValidator.TestValidate(customer);

            Assert.NotNull(result);
            Assert.NotNull(result.Errors);
            Assert.True(result.Errors.Count == 1);
            Assert.True(result.Errors.Any(it => it.ErrorMessage.Equals(expectedMessage, StringComparison.InvariantCultureIgnoreCase)));

        }
    }
}