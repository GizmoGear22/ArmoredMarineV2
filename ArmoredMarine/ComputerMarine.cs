using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    public class ComputerMarine : MarineChar
    {
        public ComputerMarine()
        {
            Strength = 1;
            Agility = 1;
            Resilience = 1;
            Perception = 1;
            
        }
        public void AssignIndividualComputerStats(MainStats stat, int[] StatsArray)
            //Stats Array is created in the HelperFunctions class, and called in the InterfaceManager
        {
            switch (stat)
            {
                case MainStats.Strength:
                    Strength += StatsArray[0];
                    break;
                case MainStats.Agility:
                    Agility += StatsArray[1];
                    break; 
                case MainStats.Resilience:
                    Resilience += StatsArray[2];
                    break; 
                case MainStats.Perception:
                    Perception += StatsArray[3];
                    break;
            }

        }


    }
}
