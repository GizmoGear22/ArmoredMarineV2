using System;
using System.Collections.Generic;

namespace ArmoredMarine
{
    class MainProgram
    {

        static void Main(string[] args)
        {

            InterfaceManager interfaceManager = new InterfaceManager(new HumanPlayerMarine());

            interfaceManager.CharStatScreen();

            interfaceManager.WeaponPicker();

            interfaceManager.GameInstance();
        }
    }
}
