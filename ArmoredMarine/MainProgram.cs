using System;
using System.Collections.Generic;

namespace ArmoredMarine
{
    class MainProgram
    {

        static void Main(string[] args)
        {
            PlayerMarine Player = new PlayerMarine();

            InterfaceManager interfaceManager = new InterfaceManager();

            interfaceManager.CharStatScreen(Player);

            Player.InsertMainWeapon();

            interfaceManager.BattleInstance(Player);
        }
    }
}
