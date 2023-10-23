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
        PlayerMarine HumanPlayer { get; set; }

        public InterfaceManager(PlayerMarine Player)
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

            HumanPlayer.ResilienceToArmor();
            HumanPlayer.ArmorWeight();

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

