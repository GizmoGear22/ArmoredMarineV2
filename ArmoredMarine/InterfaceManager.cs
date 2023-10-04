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
                if (Int32.TryParse(userAssignedValue, out var StatPoints) && StatPoints > 0 && pointsAvailable >= 0 && StatPoints <= pointsAvailable)
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

        public void BattleInstance(PlayerMarine player)
        {
            var computerPlayer = new ComputerMarine();
            var ComputerStatArray = HelperFunctions.RandomStats();
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Strength, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Agility, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Resilience, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Perception, ComputerStatArray);

            computerPlayer.InsertMainWeapon();

            FieldManager fieldManager = new FieldManager(50, 50);
            int Range = fieldManager.DistanceBetween();
            double PercentRange = HelperFunctions.RangeToAimAdjustment(Range);

            FirePhase();

            void FirePhase()
            {
                if (computerPlayer.Health > 0)
                {
                    Console.WriteLine("What will you do?");
                    Console.WriteLine("Type in the action you with from the list of options:");
                    Console.WriteLine("Fire");
                    string Action = Console.ReadLine();
                    Action = Action.ToLower();
                    if (Action == "fire")
                    {
                        player.DealRangedDamage(player.MainWeapon, PercentRange, computerPlayer.Health, player.Perception);
                    }
                }
                if (player.Health > 0)
                {
                    Console.WriteLine("Computer Acts");
                    Console.WriteLine("Computer fires!");
                    computerPlayer.DealRangedDamage(computerPlayer.MainWeapon, PercentRange, player.Health, computerPlayer.Perception);
                    Console.WriteLine($"You have {player.Health} health left.");
                }

                if (computerPlayer.Health > 0 && player.Health > 0) 
                {
                    FirePhase();
                } else if (computerPlayer.Health <= 0)
                {
                    Console.WriteLine("Player Wins!");
                } else if (player.Health <= 0) 
                {
                    Console.WriteLine("Computer Wins!");
                }
            }


        }





    }
}
