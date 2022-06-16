using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Exercice.Exercice1;

namespace Exercice.Test.Exercice1
{
    public class Multiple3Or5And7ServiceTest
    {
        internal class MultipleOf3Or5Exposed : MultipleOf3Or5
        {
            public bool ExposedExecuteIsMultiple(int value) => this.ExecuteIsMultiple(value);
        }

        internal class MultipleOf7Exposed : MultipleOf7
        {
            public bool ExposedExecuteIsMultiple(int value) => this.ExecuteIsMultiple(value);
        }

        [Theory]
        [InlineData(7, true)]
        [InlineData(8, false)]
        [InlineData(14, true)]
        [InlineData(15, false)]
        public void IsMultipleOf7(int value, bool expected)
        {
            MultipleOf7Exposed multipleOf7Exposed = new();

            var result = multipleOf7Exposed.IsMultiple(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(5, true)]
        [InlineData(9, true)]
        [InlineData(10, true)]
        [InlineData(11, false)]
        [InlineData(13, false)]
        public void IsMultipleOf3Or5(int value, bool expected)
        {
            MultipleOf3Or5Exposed multiple3Or5Exposed = new();

            var result = multiple3Or5Exposed.ExposedExecuteIsMultiple(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, false)]
        [InlineData(3, true)]
        [InlineData(5, true)]
        [InlineData(8, false)]
        [InlineData(14, true)]
        public void MultipleOf357HandlerTest(int value, bool expected)
        {
            MultipleOf357Handler handler = new();

            var result = handler.IsMultiple(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 30)]
        public void SumMultiple3Or5And7(int value, int expected)
        {
            Multiple3Or5And7Service service = new();

            var result = service.Run(value);
            Assert.Equal(expected, result);
        }
    }
}