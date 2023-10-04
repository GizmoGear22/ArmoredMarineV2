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

        
        public void CharStatScreen(PlayerMarine HumanPlayer)
        {   
            int AvailablePoints = 30;
            //MarineStats Stats = new MarineStats();
            Console.WriteLine($"Build Your Marine! You have a maximum of {AvailablePoints} stat points to use. Spend them wisely:");

            int StatCheck(string userAssignedValue, int pointsAvailable)
            {
                if (Int32.TryParse(userAssignedValue, out var StatPoints) && StatPoints > 0)
                {
                    return StatPoints;
                }

                Console.WriteLine("Put in a proper value you moron!");
                var newValue = Console.ReadLine() ?? "";
                return StatCheck(newValue, pointsAvailable);
            }

            void AssignStat(PlayerMarine.MainStats Stat, string Points)
            {
                var UserInputValue = StatCheck(Points, AvailablePoints);

                switch (Stat)
                {
                    case MarineChar.MainStats.Strength:
                         HumanPlayer.Strength += UserInputValue;
                        break;
                    case MarineChar.MainStats.Agility:
                        HumanPlayer.Agility += UserInputValue;
                        break;
                    case MarineChar.MainStats.Resilience:
                        HumanPlayer.Resilience += UserInputValue;
                        break;
                    case MarineChar.MainStats.Perception:
                        HumanPlayer.Perception += UserInputValue;
                        break;

                    default:
                        break;
                }
                
                AvailablePoints -= UserInputValue;
                Console.WriteLine($"You have {AvailablePoints} left");
            }

            Console.WriteLine("Strength: ");
            string AssignStrength = Console.ReadLine();
            AssignStat(MarineChar.MainStats.Strength, AssignStrength);


            Console.WriteLine("Agility: ");
            string AssignAgility = Console.ReadLine();
            AssignStat(MarineChar.MainStats.Agility, AssignAgility);


            Console.WriteLine("Resilience: ");
            string AssignResilience = Console.ReadLine();
            AssignStat(MarineChar.MainStats.Resilience, AssignResilience);


            Console.WriteLine("Perception: ");
            string AssignPerception = Console.ReadLine();
            AssignStat(MarineChar.MainStats.Perception, AssignPerception);


        }

        public bool BattleInstance(PlayerMarine player)
        {
            //var randomMarineStats = HelperFunctions.PopulateArrayBelow30PointsTotal();
            var computerPlayer = new ComputerMarine();
            
            
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
