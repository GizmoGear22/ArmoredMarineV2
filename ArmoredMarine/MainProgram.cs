using System;
using System.Collections.Generic;

namespace ArmoredMarine
{
    class MainProgram
    {

        static void Main(string[] args)
        {

            InterfaceManager interfaceManager = new InterfaceManager(new PlayerMarine());

            interfaceManager.CharStatScreen();

            interfaceManager.GameInstance();
        }
    }
}
