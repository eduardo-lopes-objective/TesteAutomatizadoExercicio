using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Exercice.Exercice3.Business;

namespace Exercice.Test.Exercice3
{
    public class ParseLetterToNumberHelperTest
    {
        [Theory]
        [InlineData('a', 1)]
        [InlineData('A', 27)]
        [InlineData('z', 26)]
        [InlineData('Z', 52)]
        public void ParseTest(char letter, int expected)
        {
            var result = ParseLetterToNumberHelper.Parse(letter);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('!')]
        [InlineData('@')]
        [InlineData('-')]
        [InlineData('+')]
        public void OnlyLetterAllowed(char letter)
        {
            Assert.Throws<ArgumentException>( () => ParseLetterToNumberHelper.Parse(letter));
        }
    }
}