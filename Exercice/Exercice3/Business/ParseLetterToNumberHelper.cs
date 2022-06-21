using System.Text.RegularExpressions;

namespace Exercice.Exercice3.Business
{
    public static class ParseLetterToNumberHelper
    {
        public static int Parse(char letter)
        {            
            if (!Regex.IsMatch(letter.ToString(), @"^[a-zA-Z]+$")){
                throw new ArgumentException("Apenas letras a-z ou A-Z devem ser fornecidas");
            }

            var possibleResult = char.ToUpper(letter) - 64;

            if (letter.Equals(char.ToUpper(letter)))
            {
                possibleResult += 26;
            }

            return possibleResult;
        }
    }
}