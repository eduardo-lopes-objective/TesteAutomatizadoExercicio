using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercice.Exercice1
{
    public class MultipleOf357Handler
    {
        MultipleOf3Or5 multipleOf3Or5 = new();

        public MultipleOf357Handler()
        {
            MultipleOf7 multipleOf7 = new();

            multipleOf3Or5.SetNext(multipleOf7);
        }

        public bool IsMultiple(int value)
        {
            return multipleOf3Or5.IsMultiple(value);
        }
    }
}