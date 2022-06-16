using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercice.Exercice3.Business
{
    public class DetermineNumberIsPrime
    {
        public bool IsPrime(int value)
        {
            if (value == 1) return false;
            if (value == 2) return true;
            if (value % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(value));

            for (int i = 2; i <= boundary; i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}