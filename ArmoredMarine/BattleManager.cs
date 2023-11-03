using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    class BattleManager
    {
        public BattleManager()
        {

        }
        public static bool GoFirst(Random random)
        {
            int value = random.Next(100);
            bool First;
            if (value <= 50) { First = true; } else { First = false; }
            return First;
        }
        public bool BattleInstance(HumanPlayerMarine humanPlayer)
        {
            Random random = new Random();
            bool InstanceCheck = true;

            ComputerMarine computerPlayer = new ComputerMarine();
            var ComputerStatArray = computerPlayer.RandomStats();
            computerPlayer.AssignIndividualComputerStats(MarineCharacterManager.MainStats.Strength, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineCharacterManager.MainStats.Agility, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineCharacterManager.MainStats.Resilience, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineCharacterManager.MainStats.Perception, ComputerStatArray);

            computerPlayer.ResilienceToArmor();

            computerPlayer.InsertMainWeapon(new MainWeapons.BoltRifle());

            computerPlayer.TotalWeight();

            FieldManager fieldManager = new FieldManager(50, 50);
            

            var goFirst = GoFirst(MarineCharacterManager.RandomNum);
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
                int Range = fieldManager.DistanceBetweenCharacters();
                Console.WriteLine("What will you do?");
                Console.WriteLine("Type in the action you with from the list of options:");
                Console.WriteLine("Fire\nMove Forward\nStatus");
                string Action = Console.ReadLine();
                Action = Action.ToLower();
                switch (Action)
                {
                    case "fire":
                        Console.WriteLine("Target Component:");
                        Console.WriteLine("  Head\n  Torso\n  Left Pauldron\n  Right Pauldron\n  Left Arm\n  Right Arm\n  Left Leg\n  Right Leg");
                        var input = Console.ReadLine().ToLower();
                        switch (input)
                        {
                            case "head":
                                humanPlayer.MainWeapon.DealRangedDamage(Range, computerPlayer, humanPlayer, "head");
                                break;
                            case "torso":
                                humanPlayer.MainWeapon.DealRangedDamage(Range, computerPlayer, humanPlayer, "torso");
                                break;
                            case "left pauldron":
                                humanPlayer.MainWeapon.DealRangedDamage(Range, computerPlayer, humanPlayer, "leftpauldron");
                                break;
                            case "right pauldron":
                                humanPlayer.MainWeapon.DealRangedDamage(Range, computerPlayer, humanPlayer, "rightpauldron");
                                break;
                            case "left arm":
                                humanPlayer.MainWeapon.DealRangedDamage(Range, computerPlayer, humanPlayer, "leftarm");
                                break;
                            case "right arm":
                                humanPlayer.MainWeapon.DealRangedDamage(Range, computerPlayer, humanPlayer, "rightarm");
                                break;
                            case "left leg":
                                humanPlayer.MainWeapon.DealRangedDamage(Range, computerPlayer, humanPlayer, "leftleg");
                                break;
                            case "right leg":
                                humanPlayer.MainWeapon.DealRangedDamage(Range, computerPlayer, humanPlayer, "rightleg");
                                break;
                            default:
                                Console.WriteLine("You goofed!");
                                break;
                        }
                        humanPlayer.CombatActions -= 1;
                        break;
                    case "move forward":
                        humanPlayer.PossibleMovementDistance();
                        fieldManager.ChangePlayerPosition(humanPlayer);
                        Range = fieldManager.DistanceBetweenCharacters();
                        Console.WriteLine($"You move forward! You are now {Range} meters from your enemy!");
                        humanPlayer.CombatActions -= 1;
                        break;
                    case "status":
                        foreach (var part in humanPlayer.ArmorPoints)
                        {
                            Console.WriteLine($"{part.Key}: {part.Value["ArmorValue"]}");
                        }
                        break;
                }

                if (humanPlayer.CombatActions > 0)
                {
                    ActionPhase();
                }

                if (computerPlayer.Health > 0 && humanPlayer.CombatActions == 0)
                {
                    Console.WriteLine("Enemy's turn");
                    humanPlayer.CombatActions = 2;
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
                int Range = fieldManager.DistanceBetweenCharacters();
                var randomAction = HelperFunctions.RandomNumber(100, MarineCharacterManager.RandomNum);
                if (randomAction < 50 && computerPlayer.CombatActions > 0)
                {
                    Console.WriteLine("Computer fires!");
                    computerPlayer.MainWeapon.DealRangedDamage(Range, humanPlayer, computerPlayer, computerPlayer.TargetComponentPicker());
                    Console.WriteLine($"You have {humanPlayer.Health} health left.");
                    computerPlayer.CombatActions -= 1;
                    ComputerActionPhase();
                }
                else if (randomAction > 50 && computerPlayer.CombatActions > 0)
                {
                    computerPlayer.PossibleMovementDistance();
                    fieldManager.ChangeComputerPosition(computerPlayer);
                    Range = fieldManager.DistanceBetweenCharacters();
                    Console.WriteLine($"Computer moves forward! He's now {Range} meters from you!");
                    computerPlayer.CombatActions -= 1;
                    ComputerActionPhase();
                }
                else if (humanPlayer.Health > 0 && computerPlayer.CombatActions == 0)
                {
                    Console.WriteLine("Your turn");
                    computerPlayer.CombatActions = 2;
                    ActionPhase();
                }
                else if (humanPlayer.Health <= 0)
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
