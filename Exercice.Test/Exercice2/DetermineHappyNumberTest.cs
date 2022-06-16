using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercice.Exercice2.Business;
using Xunit;

namespace Exercice.Test.Exercice2
{
    public class DetermineHappyNumberTest
    {
        [Fact]
        public void OneIsHappy()
        {
            DetermineIsHappyNumber determineIsHappyNumber = new();
            
            var result = determineIsHappyNumber.Check(1);

            Assert.True(result, "1 is happy");
        }

        [Fact]
        public void FourIsNotHappy()
        {
            DetermineIsHappyNumber determineIsHappyNumber = new();
            
            var result = determineIsHappyNumber.Check(4);

            Assert.False(result, "4 is not happy");
        }


        [Fact]
        public void SevenIsHappy()
        {
            DetermineIsHappyNumber determineIsHappyNumber = new();
            
            var result = determineIsHappyNumber.Check(7);

            Assert.True(result, "7 is happy");
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        [InlineData(7, true)]
        [InlineData(8, false)]
        [InlineData(10, true)]
        [InlineData(11, false)]
        [InlineData(13, true)]
        public void IsHappyNumber(int number, bool expected)
        {
            DetermineIsHappyNumber determineIsHappyNumber = new();
            
            var result = determineIsHappyNumber.Check(number);

            Assert.Equal(expected, result);
        }
    }
}