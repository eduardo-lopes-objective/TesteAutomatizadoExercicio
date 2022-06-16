using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercice.Exercice3.Business;
using Xunit;

namespace Exercice.Test.Exercice3
{
    public class TextToNumberServiceTest
    {
        [Theory]
        [InlineData("a", 1)]
        [InlineData("A", 27)]
        [InlineData("z", 26)]
        [InlineData("Z", 52)]
        [InlineData("az", 126)]
        public void ParseLetterToNumber(string value, int expected)
        {
            TextToNumberService service = new();

            var result = service.ConvertLetterToNumber(value);

            Assert.Equal(expected, result);
        }
    }
}