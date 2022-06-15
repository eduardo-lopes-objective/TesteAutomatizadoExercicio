using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercice.Exercice1
{
    public class MultipleOf3Or5 : MultipleOfAbstract
    {
        protected override bool ExecuteIsMultiple(int value)
        {
            Math.DivRem(value, 3, out int isDivisible3);
            Math.DivRem(value, 5, out int isDivisible5);

            return ((isDivisible3 == 0) || (isDivisible5 == 0));
        }
    }
}