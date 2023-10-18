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

            computerPlayer.InsertMainWeapon(new MainWeapons.BoltRifle());

            FieldManager fieldManager = new FieldManager(10, 10);
            int Range = fieldManager.DistanceBetween();
            double PercentRange = HelperFunctions.RangeToAimAdjustment(Range);


            var goFirst = HelperFunctions.GoFirst();
            if (goFirst == true)
            {
                Console.WriteLine("You attack first");
                ActionPhase();
            }
            else
            {
                Console.WriteLine("Enemy sneaks up on you!");
                ComputerActionPhase();
            }


            void ActionPhase()
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine("Type in the action you with from the list of options:");
                Console.WriteLine("Fire\nStatus");
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
                            player.MainWeapon.DealRangedDamage(PercentRange, computerPlayer, player, "head");
                            break;
                        case "torso":
                            player.MainWeapon.DealRangedDamage(PercentRange, computerPlayer, player, "torso");
                            break;
                        case "left pauldron":
                            player.MainWeapon.DealRangedDamage(PercentRange, computerPlayer, player, "leftpauldron");
                            break;
                        case "right pauldron":
                            player.MainWeapon.DealRangedDamage(PercentRange, computerPlayer, player, "rightpauldron");
                            break;
                        case "left arm":
                            player.MainWeapon.DealRangedDamage(PercentRange, computerPlayer, player, "leftarm");
                            break;
                        case "right arm":
                            player.MainWeapon.DealRangedDamage(PercentRange, computerPlayer, player, "rightarm");
                            break;
                        case "left leg":
                            player.MainWeapon.DealRangedDamage(PercentRange, computerPlayer, player, "leftleg");
                            break;
                        case "right leg":
                            player.MainWeapon.DealRangedDamage(PercentRange, computerPlayer, player, "rightleg");
                            break;
                        default:
                            Console.WriteLine("You goofed!");
                            break;
                    }
                    player.Actions -= 1;
                    if (player.Actions > 0)
                    {
                        ActionPhase();
                    }
                }
                else if (Action == "status")
                {
                    foreach (var part in player.ArmorPoints)
                    {
                        Console.WriteLine($"{part.Value["ArmorValue"]}");
                    }
                    ActionPhase();
                }

                if (computerPlayer.Health > 0)
                {
                    Console.WriteLine("Enemy's turn");
                    ComputerActionPhase();
                }
                else if (computerPlayer.Health <= 0)
                {
                    Console.WriteLine("You have defeated the enemy!");
                    InstanceCheck = false;
                }
            }

            void ComputerActionPhase()
            {
                Console.WriteLine("Computer Acts");
                Console.WriteLine("Computer fires!");
                computerPlayer.MainWeapon.DealRangedDamage(PercentRange, player, computerPlayer, computerPlayer.TargetComponentPicker());
                Console.WriteLine($"You have {player.Health} health left.");
                if (player.Health > 0)
                {
                    Console.WriteLine("Your turn");
                    ActionPhase();
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
