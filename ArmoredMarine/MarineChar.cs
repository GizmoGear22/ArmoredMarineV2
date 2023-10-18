using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;



namespace ArmoredMarine
{
    public class MarineChar 
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Resilience { get; set; }
        public int Perception { get; set; }
        public double Movement { get; set; }
        public double Weight { get; set; }
        public int MaxPoints { get; set; }
        public int Credits { get; set; }
        public MainWeapons MainWeapon { get; set; }
        public MainWeapons SideWeapon { get; set; }
        public MainWeapons MeleeWeapon { get; set; }


        public Dictionary<string, Dictionary<string, double>> ArmorPoints = new Dictionary<string, Dictionary<string, double>>
            {
                {"head", new Dictionary<string, double> { { "ArmorValue", 60 }, {"AccuracyMod", 0.5 } } },
                {"torso", new Dictionary<string, double> { { "ArmorValue", 130 }, {"AccuracyMod", 1 } } },
                {"leftpauldron", new Dictionary<string, double> { { "ArmorValue", 110 }, {"AccuracyMod", 0.8 } } },
                {"rightpauldron", new Dictionary<string, double> { { "ArmorValue", 110 }, {"AccuracyMod", 0.8 } } },
                {"leftarm", new Dictionary < string, double > { { "ArmorValue", 100 }, { "AccuracyMod", 0.6 } } },
                {"rightarm", new Dictionary < string, double > { { "ArmorValue", 100 }, { "AccuracyMod", 0.6 } } },
                {"leftleg", new Dictionary < string, double > { { "ArmorValue", 100 }, { "AccuracyMod", 0.6 } } },
                {"rightleg", new Dictionary < string, double > { { "ArmorValue", 100 }, { "AccuracyMod", 0.6 } } }
            } ;


        public enum MainStats
        {
            Strength,
            Agility,
            Resilience,
            Perception
        }

        public void InsertMainWeapon(IWeapons weapon)
        {
            
        }


        public void ReduceHealth(int damage)
        {
            this.Health -= damage;
        }

        public void ReduceArmor(int damage, string target)
        {
            this.ArmorPoints[target]["ArmorValue"] -= damage;
        }

    }
}


    

