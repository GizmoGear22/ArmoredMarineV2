using System;
using System.Collections.Generic;

namespace ArmoredMarine
{
    class MainProgram
    {

        static void Main(string[] args)
        {
            PlayerMarine Player = new PlayerMarine();

            Player.MainWeapon = new MainWeapons.BoltRifle();

            InterfaceManager interfaceManager = new InterfaceManager(Player);

            interfaceManager.CharStatScreen();

            interfaceManager.GameInstance();
        }
    }
}
