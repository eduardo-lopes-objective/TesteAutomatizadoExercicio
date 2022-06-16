using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercice.Exercice3.Business;
using Xunit;

namespace Exercice.Test.Exercice3
{
    public class DetermineNumberIsPrimeTest
    {
        private readonly DetermineNumberIsPrime service = null;

        public DetermineNumberIsPrimeTest()
        {
            this.service = new();

        }

        [Fact]
        public void OneIsNotPrime()
        {
            var result = service.IsPrime(1);

            Assert.False(result);
        }

        [Fact]
        public void TwoIsPrime()
        {
            var result = service.IsPrime(2);

            Assert.True(result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(9)]
        public void NumberWithZeroRestIsNotPrime(int value)
        {
            var result = service.IsPrime(value);

            Assert.False(result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(7)]
        [InlineData(17)]
        [InlineData(23)]
        [InlineData(31)]
        public void ArePrime(int value)
        {
            var result = service.IsPrime(value);

            Assert.True(result);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(18)]
        [InlineData(24)]
        [InlineData(32)]
        public void AreNotPrime(int value)
        {
            var result = service.IsPrime(value);

            Assert.False(result);
        }
    }
}