using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using static ArmoredMarine.HelperFunctions;

namespace ArmoredMarine
{
    public class HelperFunctions
    {
            public static int RandomNumber(int num, Random rnd)
        {
           int GeneratedNumber = rnd.Next(num);
            return GeneratedNumber;
        }

        public static void Shuffle<T>(T[] array, Random _random) //Pulled as Fisher-Yates Shuffle Algorithm. I'll figure out how it works later =/
        {
            int n = array.Length;
            for (int i = 0; i < (n - 1); i++)
            {
                int r = i + _random.Next(n - i);
                (array[i], array[r]) = (array[r], array[i]);
            }
        }
        public static bool GoFirst(Random random)
        {

            int value = random.Next(100);
            bool First;
            if (value <= 50) { First = true; } else { First = false; }
            return First;
        }

        public static double RangeToAimAdjustment(double range)
        {
            double RangeAimAdjust = (range + 2.5) / (2.2 * range);
            return RangeAimAdjust;
        }
   
    }

}
