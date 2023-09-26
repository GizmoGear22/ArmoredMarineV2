using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ArmoredMarine;

namespace ArmoredMarine
{
    public class MarineManager
    {
        private MarineChar _player { get; set; }

        public MarineManager(MarineChar marinechar)
        {
            _player = marinechar;
        }


        //     

        //MarineChar Player = new MarineChar(AssignStrength, AssignAgility, AssignResilience, AssignPerception);
        //Weapons weapons = new Weapons();

        //bool ShopVisit = false;

        //while (!ShopVisit)
        //{
        //    Console.WriteLine("Welcome to the Armoury! Redeem credits for items to equip yourself. Type in what you want to equip. To leave for the battlefield, type exit. Here's what we have:");
        //    Console.WriteLine(Player.Credits);
        //    Console.WriteLine($"Boltrifle (standard): {weapons.BoltRifle["Cost"]}");
        //    Console.WriteLine($"Auto Boltrifle: {weapons.autoboltrifle["Cost"]}");

        //    Console.WriteLine("Exit");
        //    string input = Console.ReadLine();

        //    if (input == "boltrifle")
        //    {
        //        var marineChar = new MarineChar();
        //        marineChar.SpendMoney(Player.Credits, weapons.BoltRifle["Cost"]);


        //    }

        //    if (input == "exit")
        //    {
        //        ShopVisit = true;
        //    };
    }
}
