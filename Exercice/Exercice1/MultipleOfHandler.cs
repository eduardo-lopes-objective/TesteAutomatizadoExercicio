using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercice.Exercice1
{
    public class MultipleOfHandler
    {
        MultipleOf3 multipleOf3 = new();

        public MultipleOfHandler()
        {
            MultipleOf5 multipleBy5 = new();

            multipleOf3.SetNext(multipleBy5);
        }

        public bool IsMultiple(int value)
        {
            return multipleOf3.IsMultiple(value);
        }
    }
}