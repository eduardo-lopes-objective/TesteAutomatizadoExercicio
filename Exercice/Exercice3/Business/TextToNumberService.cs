using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercice.Exercice3.Business
{
    public class TextToNumberService
    {
        public int ConvertLetterToNumber(string text)
        {
            var helper = string.Empty;
            foreach (char character in text)
            {
                helper += ParseLetterToNumberHelper.Parse(character);
            }

            return Convert.ToInt32(helper);
        }
    }
}