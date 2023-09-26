using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    public class InterfaceManager
    {
        
        public MarineStats CharStatScreen()
        {   
            int AvailablePoints = 30;
            MarineStats Stats = new MarineStats();
            Console.WriteLine($"Build Your Marine! You have a maximum of {AvailablePoints} stat points to use. Spend them wisely:");

            bool AssignStat(string Stat, int Points)
            {
                if (HelperFunctions.InputChecker(Stat, Points) == false) 
                {
                    Console.WriteLine("Input a correct value you moron!");
                    Stat = Console.ReadLine();
                    AssignStat(Stat, Points);
                }

                int i = Convert.ToInt32( Stat );
                Points -= i;
                Stats.Add(i);
                Console.WriteLine($"You have {Points} left");
                AvailablePoints = Points;
                return true;
            }

            Console.WriteLine("Strength: ");
            string AssignStrength = Console.ReadLine();
            AssignStat(AssignStrength, AvailablePoints);

            Console.WriteLine("Agility: ");
            string AssignAgility = Console.ReadLine();
            AssignStat(AssignAgility, AvailablePoints);

            Console.WriteLine("Resilience: ");
            string AssignResilience = Console.ReadLine();
            AssignStat(AssignResilience, AvailablePoints);

            Console.WriteLine("Perception: ");
            string AssignPerception = Console.ReadLine();
            AssignStat(AssignPerception, AvailablePoints);

            return Stats;
        }

        public bool BattleInstance(PlayerMarine player)
        {
            var randomMarineStats = HelperFunctions.RandomStats();
            var marine = new MarineStats()
            {
                Strength = randomMarineStats[0],
                Agility = randomMarineStats[1],
                Resilience = randomMarineStats[2],
                Perception = randomMarineStats[3]

            };
            ComputerMarine computerPlayer = new ComputerMarine(marine);
            computerPlayer.InsertMainWeapon();

            FieldManager fieldManager = new FieldManager(50, 50);
            int Range = fieldManager.DistanceBetween();
            double PercentRange = HelperFunctions.RangeToAimAdjustment(Range);

            Console.WriteLine("What will you do?");
            Console.WriteLine("Type in the action you with from the list of options:");
            Console.WriteLine("Fire");
            string Action = Console.ReadLine(); 
            Action = Action.ToLower();
            if (Action == "fire")
            {
                player.DealRangedDamage(player.MainWeapon, PercentRange, computerPlayer.Health);
   
            }


            return true;
        }





    }
}
