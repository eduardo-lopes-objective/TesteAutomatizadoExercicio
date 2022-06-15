using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercice.Exercice1
{
    public abstract class MultipleOfAbstract
    {
        protected MultipleOfAbstract? NextHandler = null;

        public void SetNext(MultipleOfAbstract next)
        {
            this.NextHandler = next;
        }

        public bool IsMultiple(int value)
        {
            var response = ExecuteIsMultiple(value);

            if (!response && this.NextHandler != null)
            {
                return this.NextHandler.ExecuteIsMultiple(value);
            }

            return response;
        }

        protected abstract bool ExecuteIsMultiple(int value);
    }
}