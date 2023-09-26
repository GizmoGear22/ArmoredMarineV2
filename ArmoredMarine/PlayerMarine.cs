using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    public class PlayerMarine : MarineChar
    {
        public PlayerMarine(MarineStats stats)
        {
            MarineStats = stats;
            
        }

        public void SpendMoney(int CurrentMoney, double ItemCost)
        {
            int intCost = Convert.ToInt32(ItemCost);
            CurrentMoney -= intCost;
            Console.WriteLine(CurrentMoney);
        }

        
    }
}
