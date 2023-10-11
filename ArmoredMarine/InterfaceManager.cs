using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    public class InterfaceManager
    {
        private bool instanceCheck { get; set; }
        public bool gameOver { get; set; }

        public InterfaceManager()
        {
            instanceCheck = false; //turns true during sequence activation. False when turning to new sequence.
            gameOver = false;
        }

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

        public bool BattleInstance(PlayerMarine player)
        {
            instanceCheck = true;

            ComputerMarine computerPlayer = new ComputerMarine();
            var ComputerStatArray = HelperFunctions.RandomStats();
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Strength, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Agility, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Resilience, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Perception, ComputerStatArray);

            computerPlayer.InsertMainWeapon();

            FieldManager fieldManager = new FieldManager(50, 50);
            int Range = fieldManager.DistanceBetween();
            double PercentRange = HelperFunctions.RangeToAimAdjustment(Range);


            var goFirst = HelperFunctions.GoFirst();
            if (goFirst == true)
            {
                Console.WriteLine("You attack first");
                PlayerFirePhase();
            }
            else
            {
                Console.WriteLine("Enemy sneaks up on you!");
                ComputerFirePhase();
            }


            void PlayerFirePhase()
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("Type in the action you with from the list of options:");
                Console.WriteLine("Fire");
                string Action = Console.ReadLine();
                Action = Action.ToLower();
                if (Action == "fire")
                {
                    player.DealRangedDamage(player.MainWeapon, PercentRange, computerPlayer, player);
                }
                if (computerPlayer.Health >  0)
                {
                    Console.WriteLine("Enemy's turn");
                    ComputerFirePhase();
                } else if (computerPlayer.Health <= 0)
                {
                    Console.WriteLine("You have defeated the enemy!");
                    instanceCheck = false;
                }
            }

            void ComputerFirePhase()
            {
                Console.WriteLine("Computer Acts");
                Console.WriteLine("Computer fires!");
                computerPlayer.DealRangedDamage(computerPlayer.MainWeapon, PercentRange, player, computerPlayer);
                Console.WriteLine($"You have {player.Health} health left.");
            } if (player.Health > 0)
            {
                Console.WriteLine("Your turn");
                PlayerFirePhase();
            } else if (player.Health <= 0)
            {
                Console.WriteLine("You died");
                instanceCheck = false;
                gameOver = true;

            }
            if (instanceCheck == false)
            {
                return false;
            }
            return true;
        }
        /*
            bool HealthCheck()
            {
                if (player.Health <= 0)
                {
                    Console.WriteLine("You're Dead");
                    return false;
                }
                if (computerPlayer.Health <= 0)
                {
                    Console.WriteLine("You are victorious!");
                    return false;
                }
                if (player.Health > 0 && computerPlayer.Health > 0) 
                {
                    Console.WriteLine("The Battle Continues");
                    return true;
                }
                return true;
            }
        */

    }

}

