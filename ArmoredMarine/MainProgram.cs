using System;
using System.Collections.Generic;

namespace ArmoredMarine
{
    class MainProgram
    {

        static void Main(string[] args)
        {
            InterfaceManager interfaceManager = new InterfaceManager();

            MarineStats MarineStats = interfaceManager.CharStatScreen();

            PlayerMarine Player = new PlayerMarine(MarineStats);

            Player.InsertMainWeapon();

            interfaceManager.BattleInstance(Player);
        }
    }
}
