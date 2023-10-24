using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

        public delegate void SendToConsole(string message);
        private SendToConsole _handlers;

        public void RegisterSpeakerHandler(SendToConsole handler)
        {
            _handlers = handler;
        }



        public bool BattleInstance(PlayerMarine player)
        {
            Random random = new Random();
            bool InstanceCheck = true;

            RegisterSpeakerHandler(ConsoleWriter);

            void ConsoleWriter(string msg)
            {
                Console.WriteLine($"{msg}", _handlers);
            }

            ComputerMarine computerPlayer = new ComputerMarine();
            var ComputerStatArray = computerPlayer.RandomStats();
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Strength, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Agility, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Resilience, ComputerStatArray);
            computerPlayer.AssignIndividualComputerStats(MarineChar.MainStats.Perception, ComputerStatArray);

            computerPlayer.ResilienceToArmor();

            computerPlayer.InsertMainWeapon(new MainWeapons.BoltRifle());

            computerPlayer.TotalWeight();

            FieldManager fieldManager = new FieldManager(50, 50);
            

            var goFirst = HelperFunctions.GoFirst(MarineChar.RandomNum);
            if (goFirst == true)
            {
                _handlers.Invoke("You attack first");
                ActionPhase();
            }
            else
            {
                _handlers.Invoke("Enemy sneaks up on you!");
                ComputerActionPhase();
            }

            void ActionPhase()
            {
                int Range = fieldManager.DistanceBetween();
                _handlers.Invoke("What will you do?");
                _handlers.Invoke("Type in the action you with from the list of options:");
                _handlers.Invoke("Fire\nMove Forward\nStatus");
                string Action = Console.ReadLine();
                Action = Action.ToLower();
                switch (Action)
                {
                    case "fire":
                        _handlers.Invoke("Target Component:");
                        _handlers.Invoke("  Head\n  Torso\n  Left Pauldron\n  Right Pauldron\n  Left Arm\n  Right Arm\n  Left Leg\n  Right Leg");
                        var input = Console.ReadLine().ToLower();
                        switch (input)
                        {
                            case "head":
                                player.MainWeapon.DealRangedDamage(Range, computerPlayer, player, "head");
                                break;
                            case "torso":
                                player.MainWeapon.DealRangedDamage(Range, computerPlayer, player, "torso");
                                break;
                            case "left pauldron":
                                player.MainWeapon.DealRangedDamage(Range, computerPlayer, player, "leftpauldron");
                                break;
                            case "right pauldron":
                                player.MainWeapon.DealRangedDamage(Range, computerPlayer, player, "rightpauldron");
                                break;
                            case "left arm":
                                player.MainWeapon.DealRangedDamage(Range, computerPlayer, player, "leftarm");
                                break;
                            case "right arm":
                                player.MainWeapon.DealRangedDamage(Range, computerPlayer, player, "rightarm");
                                break;
                            case "left leg":
                                player.MainWeapon.DealRangedDamage(Range, computerPlayer, player, "leftleg");
                                break;
                            case "right leg":
                                player.MainWeapon.DealRangedDamage(Range, computerPlayer, player, "rightleg");
                                break;
                            default:
                                _handlers.Invoke("You goofed!");
                                break;
                        }
                        player.Actions -= 1;
                        break;
                    case "move forward":
                        player.TotalMovement();
                        fieldManager.ReducePlayerPosition(player);
                        Range = fieldManager.DistanceBetween();
                        _handlers.Invoke($"You move forward! You are now {Range} meters from your enemy!");
                        player.Actions -= 1;
                        break;
                    case "status":
                        foreach (var part in player.ArmorPoints)
                        {
                            _handlers.Invoke($"{part.Key}: {part.Value["ArmorValue"]}");
                        }
                        break;
                }

                if (player.Actions > 0)
                {
                    ActionPhase();
                }

                if (computerPlayer.Health > 0 && player.Actions == 0)
                {
                    _handlers.Invoke("Enemy's turn");
                    player.Actions = 2;
                    ComputerActionPhase();
                }
                else if (computerPlayer.Health <= 0)
                {
                    _handlers.Invoke("You have defeated the enemy!");
                    InstanceCheck = false;
                }
            }

            void ComputerActionPhase()
            {
                _handlers.Invoke("Computer Acts");
                int Range = fieldManager.DistanceBetween();
                var randomAction = HelperFunctions.RandomNumber(100, MarineChar.RandomNum);
                if (randomAction < 50 && computerPlayer.Actions > 0)
                {
                    _handlers.Invoke("Computer fires!");
                    computerPlayer.MainWeapon.DealRangedDamage(Range, player, computerPlayer, computerPlayer.TargetComponentPicker());
                    _handlers.Invoke($"You have {player.Health} health left.");
                    computerPlayer.Actions -= 1;
                    ComputerActionPhase();
                }
                else if (randomAction > 50 && computerPlayer.Actions > 0)
                {
                    computerPlayer.TotalMovement();
                    fieldManager.ReduceComputerPosition(computerPlayer);
                    Range = fieldManager.DistanceBetween();
                    _handlers.Invoke($"Computer moves forward! He's now {Range} meters from you!");
                    computerPlayer.Actions -= 1;
                    ComputerActionPhase();
                }
                else if (player.Health > 0 && computerPlayer.Actions == 0)
                {
                    _handlers.Invoke("Your turn");
                    computerPlayer.Actions = 2;
                    ActionPhase();
                }
                else if (player.Health <= 0)
                    {
                        _handlers.Invoke("You died");
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
