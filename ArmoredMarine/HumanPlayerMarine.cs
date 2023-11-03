﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    public class HumanPlayerMarine : MarineCharacterManager
    {
        public HumanPlayerMarine()
        {
            Strength = 1;
            Agility = 1;
            Resilience = 1;
            Perception = 1;
            Health = 100;
        }

        public void SpendMoney(int CurrentMoney, double ItemCost)
        {
            int intCost = Convert.ToInt32(ItemCost);
            CurrentMoney -= intCost;
            Console.WriteLine(CurrentMoney);
        }

        
    }
}