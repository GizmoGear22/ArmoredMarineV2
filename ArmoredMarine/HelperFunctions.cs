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

        static void Shuffle<T>(T[] array) //Pulled as Fisher-Yates Shuffle Algorithm. I'll figure out how it works later =/
        {
            Random _random = new Random();
            int n = array.Length;
            for (int i = 0; i < (n - 1); i++)
            {
                int r = i + _random.Next(n - i);
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
        public static int[] RandomStats()
        {
            var statPointsAvailable = 30;
            int[] statStorage = new int[4];
            for (int i = 0; i < 4; i++)
            {
                var stat = RandomNumber(10);
                var currentStatTotal = statPointsAvailable;
                statPointsAvailable -= stat;
                if (statPointsAvailable <= 0)
                {
                    stat = currentStatTotal;
                }
                statStorage[i] = stat;
            }
            Shuffle(statStorage);
            return statStorage;
        }

        public static bool GoFirst()
        {
            Random random = new Random();
            int value = random.Next(1);
            bool First;
            if (value == 0) { First = true; } else { First = false; }
            return First;
        }

        public static double RangeToAimAdjustment(double range)
        {
            double RangeAimAdjust = (-.01 * range) + 1.4;
            return RangeAimAdjust;
        }
   
    }

}
