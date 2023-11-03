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

        public bool GameOver { get; set; }
        HumanPlayerMarine HumanPlayer { get; set; }

        public InterfaceManager(HumanPlayerMarine Player)
        {
            GameOver = false;
            HumanPlayer = Player;
        }

        public void CharStatScreen()
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

            void AssignStat(HumanPlayerMarine.MainStats Stat, string Points)
            {
                var PlayerStatInputValue = StatCheck(Points, AvailablePoints);

                switch (Stat)
                {
                    case MarineCharacterManager.MainStats.Strength:
                        HumanPlayer.Strength += PlayerStatInputValue;
                        break;
                    case MarineCharacterManager.MainStats.Agility:
                        HumanPlayer.Agility += PlayerStatInputValue;
                        break;
                    case MarineCharacterManager.MainStats.Resilience:
                        HumanPlayer.Resilience += PlayerStatInputValue;
                        break;
                    case MarineCharacterManager.MainStats.Perception:
                        HumanPlayer.Perception += PlayerStatInputValue;
                        break;

                    default:
                        break;
                }

                AvailablePoints -= PlayerStatInputValue;
                Console.WriteLine($"You have {AvailablePoints} left");
            }

            Console.WriteLine("Strength: ");
            string AssignStrength = Console.ReadLine();
            AssignStat(MarineCharacterManager.MainStats.Strength, AssignStrength);


            Console.WriteLine("Agility: ");
            string AssignAgility = Console.ReadLine();
            AssignStat(MarineCharacterManager.MainStats.Agility, AssignAgility);


            Console.WriteLine("Resilience: ");
            string AssignResilience = Console.ReadLine();
            AssignStat(MarineCharacterManager.MainStats.Resilience, AssignResilience);


            Console.WriteLine("Perception: ");
            string AssignPerception = Console.ReadLine();
            AssignStat(MarineCharacterManager.MainStats.Perception, AssignPerception);

            HumanPlayer.ResilienceToArmor();

        }


        //This is a temporary method in order to implement weapons interface
        public void WeaponPicker()
        {
            Console.WriteLine("Pick your weapon:\n BoltRifle\n AutoBoltRifle");
            var playerChoice = Console.ReadLine().ToLower();
            switch (playerChoice)
            {
                case "boltrifle":
                    HumanPlayer.InsertMainWeapon(new MainWeapons.BoltRifle());
                    break;
                case "autoboltrifle":
                    HumanPlayer.InsertMainWeapon(new MainWeapons.AutoBoltRifle());
                    break;
                default:
                    Console.WriteLine("Pick you proper weapon you dolt!");
                    WeaponPicker();
                    break;
            }
        }

        public bool GameInstance()
        {
            HumanPlayer.TotalWeight();

            BattleManager Battle = new BattleManager();
             if (Battle.BattleInstance(HumanPlayer) == false)
            {
                GameOver = true;
                return false;
            }
            return true;
        }

    }

}

