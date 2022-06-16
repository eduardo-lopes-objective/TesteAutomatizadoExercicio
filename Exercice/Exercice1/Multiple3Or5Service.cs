using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercice.Exercice1
{
    public class Multiple3Or5Service
    {
        private MultipleOfHandler MultipleOfHandler = new();

        public int Run(int amountRecords)
        {
            var response = 0;

            for (var index = 1; index < amountRecords; index++)
            {
                if (IsMultiple(index))
                {
                    response += index;
                }
            }

            return response;
        }

        public bool IsMultiple(int value) => MultipleOfHandler.IsMultiple(value);
    }
}