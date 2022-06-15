using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercice.Exercice1
{
    public class MultipleOf5 : MultipleOfAbstract
    {
        protected override bool ExecuteIsMultiple(int value)
        {
            Math.DivRem(value, 5, out int isDivisible);

            return isDivisible == 0;
        }
    }
}