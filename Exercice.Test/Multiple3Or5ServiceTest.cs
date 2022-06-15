using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Exercice.Exercice1;

namespace Exercice.Test
{
    internal class MultipleOf3Exposed : MultipleOf3
    {
        public bool ExposedExecuteIsMultiple(int value) => this.ExecuteIsMultiple(value);
    }

    internal class MultipleOf5Exposed : MultipleOf5
    {
        public bool ExposedExecuteIsMultiple(int value) => this.ExecuteIsMultiple(value);
    }

    public class Multiple3Or5ServiceTest
    {
        [Theory]
        [InlineData(3, true)]
        [InlineData(5, false)]
        [InlineData(9, true)]
        public void IsMultipleOf3(int value, bool expected)
        {
            MultipleOf3Exposed multipleOf3Exposed = new();

            var result = multipleOf3Exposed.ExposedExecuteIsMultiple(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(5, true)]
        [InlineData(9, false)]
        [InlineData(10, true)]
        public void IsMultipleOf5(int value, bool expected)
        {
            MultipleOf5Exposed multipleOf5Exposed = new();

            var result = multipleOf5Exposed.ExposedExecuteIsMultiple(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(5, true)]
        [InlineData(7, false)]
        [InlineData(12, true)]
        [InlineData(15, true)]
        public void MultipleOfHandlerTest(int value, bool expected)
        {
            MultipleOfHandler MultipleOfHandler = new();

            var result = MultipleOfHandler.IsMultiple(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 23)]
        [InlineData(20, 78)]
        public void Multiple3Or5Service(int maxValue, int expected)
        {
            Multiple3Or5Service multiple3Or5Service = new();

            var result = multiple3Or5Service.Run(maxValue);

            Assert.Equal(expected, result);
        }
    }
}