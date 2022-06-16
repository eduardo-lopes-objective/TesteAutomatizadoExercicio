using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercice.Exercice2.Business
{
    public class DetermineIsHappyNumber
    {
        public bool Check(int value)
        {
            var result = value;

            while (result != 1 && result != 4)
            {
                result = ExecuteHappyNumber(result);
            }

            if (result == 1)
            {
                return true;
            }

            if (result == 4)
            {
                return false;
            }

            return false;
        }

        private int ExecuteHappyNumber(int number){
            int rem = 0;
            int sum = 0;

            while(number > 0){
                rem = number % 10;
                sum = sum + (rem * rem);
                number = number / 10;
            }

            return sum;
        }
    }
}