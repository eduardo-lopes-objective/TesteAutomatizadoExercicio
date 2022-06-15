using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercice.Exercice1
{
    public class Multiple3Or5And7Service
    {
        public int Run(int amountRecords)
        {
            var response = 0;

            MultipleOf357Handler handler = new();

            for (var index = 1; index < amountRecords; index++)
            {
                if (handler.IsMultiple(index))
                {
                    response += index;
                }
            }

            return response;
        }
    }
}