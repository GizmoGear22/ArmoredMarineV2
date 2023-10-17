using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    class BattleManager
    {
        public BattleManager()
        {

        }
        public bool BattleInstance(PlayerMarine player)
        {
            bool InstanceCheck = true;

            ComputerMarine computerPlayer = new ComputerMarine();
            var ComputerStatArray = computerPlayer.RandomStats();
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Strength, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Agility, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Resilience, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Perception, ComputerStatArray);

            computerPlayer.InsertMainWeapon();

            FieldManager fieldManager = new FieldManager(10, 10);
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
                Console.WriteLine("Fire\nstatus");
                string Action = Console.ReadLine();
                Action = Action.ToLower();
                if (Action == "fire")
                {
                    Console.WriteLine("Target Component:");
                    Console.WriteLine("  Head\n  Torso\n  Left Pauldron\n  Right Pauldron\n  Left Arm\n  Right Arm\n  Left Leg\n  Right Leg");
                    var input = Console.ReadLine().ToLower();
                    switch (input)
                    {
                        case "head":
                            player.DealRangedDamage(PercentRange, computerPlayer, player, "head");
                            break;
                        case "torso":
                            player.DealRangedDamage(PercentRange, computerPlayer, player, "torso");
                            break;
                        case "left pauldron":
                            player.DealRangedDamage(PercentRange, computerPlayer, player, "leftpauldron");
                            break;
                        case "right pauldron":
                            player.DealRangedDamage(PercentRange, computerPlayer, player, "rightpauldron");
                            break;
                        case "left arm":
                            player.DealRangedDamage(PercentRange, computerPlayer, player, "leftarm");
                            break;
                        case "right arm":
                            player.DealRangedDamage(PercentRange, computerPlayer, player, "rightarm");
                            break;
                        case "left leg":
                            player.DealRangedDamage(PercentRange, computerPlayer, player, "leftleg");
                            break;
                        case "right leg":
                            player.DealRangedDamage(PercentRange, computerPlayer, player, "rightleg");
                            break;
                        default:
                            Console.WriteLine("You goofed!");
                            break;
                    }
                    //player.DealRangedDamage(PercentRange, computerPlayer, player);
                }
                else if (Action == "status")
                {
                    foreach (var part in player.ArmorPoints)
                    {
                        Console.WriteLine($"{part.Value["ArmorValue"]}");
                    }
                    PlayerFirePhase();
                }

                if (computerPlayer.Health > 0)
                {
                    Console.WriteLine("Enemy's turn");
                    ComputerFirePhase();
                }
                else if (computerPlayer.Health <= 0)
                {
                    Console.WriteLine("You have defeated the enemy!");
                    InstanceCheck = false;
                }
            }

            void ComputerFirePhase()
            {
                Console.WriteLine("Computer Acts");
                Console.WriteLine("Computer fires!");
                computerPlayer.DealRangedDamage(PercentRange, player, computerPlayer, computerPlayer.TargetComponentPicker());
                Console.WriteLine($"You have {player.Health} health left.");
                if (player.Health > 0)
                {
                    Console.WriteLine("Your turn");
                    PlayerFirePhase();
                }
                else if (player.Health <= 0)
                {
                    Console.WriteLine("You died");
                    InstanceCheck = false;

                }
            }

            if (InstanceCheck == false)
            {
                return false;
            }
            return true;
        }


    }
}
