using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    public class MainWeapons : IWeapons 
    { 

        public int Ammo { get; set; }
        public double Accuracy { get; protected set; }
        public int Damage { get; protected set; }
        public int Cost { get; protected set; }
        public int ShotsPerRound { get; protected set; }

        /*
        public Weapons(int ammo, double accuracy, int damage, int cost )
        {
            Ammo = ammo;
            Accuracy = accuracy;
            Damage = damage;
            Cost = cost;
        }
        */

        public class BoltRifle : MainWeapons
        {
            public BoltRifle()
            {
                Ammo = 40;
                Accuracy = 0.6;
                Damage = 10;
                Cost = 300;
                ShotsPerRound = 10;
            }
        }

/*
        public Dictionary<string, double> autoboltrifle = new Dictionary<string, double>
        {
            {"Ammo", 40 },
            {"Accuracy", 0.5 },
            {"damage", 10 },
            {"Cost", 400 }
        };


*/



 
        

         
    }
}
