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
        public static bool InputChecker(string SmallInput, int LargeInput)
        {
            bool checkInput = int.TryParse(SmallInput, out var IntInput);
            
            if (!checkInput)
            {
                return false;
            }
            else
            {
                IntInput = Convert.ToInt32(SmallInput);
            }
            if (IntInput < 0)
            {
                return false;
            }
            if (LargeInput < 0)
            {
                return false;
            }
            return true;
        }


        public static int RandomNumber(int num)
        {
            Random rnd = new Random();
           int GeneratedNumber = rnd.Next(num);
            return GeneratedNumber;
        }       
        public static int[] RandomStats() 
        {
            int[] stats = new int[4];
            for (int i = 0; i<stats.Length; i++)
            {
                stats[i] = RandomNumber(15);
            }
            int result = 0;

            for (int i = 0; i<stats.Length; i++)
            {
                result += stats[i];
            }
            if (result > 30)
            {
                RandomStats();
            }
            return stats;
        }

        public static int[] PopulateArrayBelow30PointsTotal()
        {
            var points = 30;
            var result = new int[4];
            for (int i = 0; i<result.Length; i++)
            {
                result[i] = RandomNumber(points);
                points -= result[i];
            }
            return result;
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
