using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    public class ComputerMarine : MarineCharacter
    {
        public ComputerMarine()
        {
            Strength = 1;
            Agility = 1;
            Resilience = 1;
            Perception = 1;
            Health = 100;
            
        }
        public int[] RandomStats()
        {
 
            var statPointsAvailable = 30;
            int[] statStorage = new int[4];
            for (int i = 0; i < 4; i++)
            {
                var stat = HelperFunctions.RandomNumber(10, MarineCharacter.RandomNum);
                var currentStatTotal = statPointsAvailable;
                statPointsAvailable -= stat;
                if (statPointsAvailable <= 0)
                {
                    stat = currentStatTotal;
                }
                statStorage[i] = stat;
            }
            HelperFunctions.Shuffle(statStorage, MarineCharacter.RandomNum);
            return statStorage;
        }
        public void AssignIndividualComputerStats(MainStats stat, int[] StatsArray)
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

        public string TargetComponentPicker()
        {
            string chosenComponent = "";
            switch(HelperFunctions.RandomNumber(7,MarineCharacter.RandomNum))
            {
                case 0:
                    chosenComponent = "head";
                    break;
                case 1:
                    chosenComponent = "torso";
                    break;
                case 2:
                    chosenComponent = "leftpauldron";
                    break;
                case 3:
                    chosenComponent = "rightpauldron";
                    break;
                case 4:
                    chosenComponent = "leftarm";
                    break;
                case 5:
                    chosenComponent = "rightarm";
                    break;
                case 6:
                    chosenComponent = "leftleg";
                    break;
                case 7:
                    chosenComponent = "rightleg";
                    break;
            }
            return chosenComponent;

        }


    }
}
