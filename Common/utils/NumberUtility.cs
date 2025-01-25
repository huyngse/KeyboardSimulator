using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.utils
{
    public static class NumberUtility
    {
        private static Random random = new Random();
        public static int GenerateRandomInteger(int min, int max)
        {
            // Ensure max is greater than min
            if (min >= max)
            {
                throw new ArgumentException("Max must be greater than min.");
            }

            return random.Next(min, max);
        }
    }
}
