using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercice.Exercice1
{
    public class Multiple3Or5Service
    {
        public int Run(int amountRecords)
        {
            var response = 0;

            MultipleOfHandler MultipleOfHandler = new();

            for (var index = 1; index < amountRecords; index++)
            {
                if (MultipleOfHandler.IsMultiple(index))
                {
                    response += index;
                }
            }

            return response;
        }
    }
}