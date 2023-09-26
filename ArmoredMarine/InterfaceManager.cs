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

            bool AssignStat(string Stat, string Points)
            {
                var canParse = Int32.TryParse(Points, out var usedPoints);
                {
                    if (!canParse || String.IsNullOrEmpty(Stat))
                    {
                        Console.WriteLine("Input a correct value you moron!");
                        Stat = Console.ReadLine();

                    }
                }
                

                switch (Stat)
                {
                    case "Strength":
                        Stats.Strength = usedPoints;
                        break;
                    case "Agility":
                        Stats.Agility = usedPoints;
                        break;
                    case "Resilience":
                        Stats.Resilience = usedPoints;
                        break;
                    case "Perception":
                        Stats.Perception = usedPoints;
                        break;

                    default:
                        break;
                }
                AvailablePoints -= usedPoints;
                Console.WriteLine($"You have {AvailablePoints} left");
                return true;
            }

            Console.WriteLine("Strength: ");
            string AssignStrength = Console.ReadLine();
            AssignStat("Strength", AssignStrength);

            Console.WriteLine("Agility: ");
            string AssignAgility = Console.ReadLine();
            AssignStat("Agility", AssignAgility);

            Console.WriteLine("Resilience: ");
            string AssignResilience = Console.ReadLine();
            AssignStat("Resilience", AssignResilience);

            Console.WriteLine("Perception: ");
            string AssignPerception = Console.ReadLine();
            AssignStat("Perception", AssignPerception);

            return Stats;
        }

        public bool BattleInstance(PlayerMarine player)
        {
            var randomMarineStats = HelperFunctions.PopulateArrayBelow30PointsTotal();

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
                player.DealRangedDamage(player.MainWeapon, PercentRange, computerPlayer.MarineStats.Health);
   
            }


            return true;
        }





    }
}
