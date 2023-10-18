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
            public static int RandomNumber(int num)
        {
            Random rnd = new Random();
           int GeneratedNumber = rnd.Next(num);
            return GeneratedNumber;
        }

        public static void Shuffle<T>(T[] array) //Pulled as Fisher-Yates Shuffle Algorithm. I'll figure out how it works later =/
        {
            Random _random = new Random();
            int n = array.Length;
            for (int i = 0; i < (n - 1); i++)
            {
                int r = i + _random.Next(n - i);
                (array[i], array[r]) = (array[r], array[i]);
            }
        }
        public static bool GoFirst()
        {
            Random random = new Random();
            int value = random.Next(2);
            bool First;
            if (value == 0) { First = true; } else { First = false; }
            return First;
        }

        public static double RangeToAimAdjustment(double range)
        {
            double RangeAimAdjust = (-.009 * range) + 0.9;
            return RangeAimAdjust;
        }
   
    }

}
