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
    public class MarineChar : IWeight
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
        public int Actions { get; set; } = 2;
        public IWeapons MainWeapon { get; set; }
        public IWeapons SideWeapon { get; set; }
        public IWeapons MeleeWeapon { get; set; }


        public Dictionary<string, Dictionary<string, double>> ArmorPoints = new Dictionary<string, Dictionary<string, double>>
            {
                {"head", new Dictionary<string, double> { { "ArmorValue", .60 }, {"AccuracyMod", 0.6 } } },
                {"torso", new Dictionary<string, double> { { "ArmorValue", 1.30 }, {"AccuracyMod", 1.2 } } },
                {"leftpauldron", new Dictionary<string, double> { { "ArmorValue", 1.10 }, {"AccuracyMod", 1 } } },
                {"rightpauldron", new Dictionary<string, double> { { "ArmorValue", 1.10 }, {"AccuracyMod", 1 } } },
                {"leftarm", new Dictionary < string, double > { { "ArmorValue", .800 }, { "AccuracyMod", 0.8 } } },
                {"rightarm", new Dictionary < string, double > { { "ArmorValue", .800 }, { "AccuracyMod", 0.8 } } },
                {"leftleg", new Dictionary < string, double > { { "ArmorValue", .800 }, { "AccuracyMod", 0.8 } } },
                {"rightleg", new Dictionary < string, double > { { "ArmorValue", .800 }, { "AccuracyMod", 0.8 } } }
            } ;

        public enum MainStats
        {
            Strength,
            Agility,
            Resilience,
            Perception
        }

        public void ResilienceToArmor()
        {
            foreach (var part in ArmorPoints)
            {
                part.Value["ArmorValue"] = Math.Floor(part.Value["ArmorValue"] * Resilience * 10);
            }
        }

        public void InsertMainWeapon(IWeapons weapon)
        {
            MainWeapon = weapon;
            
        }
        public static Random RandomNum = new Random();

        public void ReduceHealth(int damage)
        {
            this.Health -= damage;
        }

        public void ReduceArmor(int damage, string target)
        {
            this.ArmorPoints[target]["ArmorValue"] -= damage;
        }

        public double GetWeight()
        {
            double totalWeight = 0;
            foreach (var part in ArmorPoints)
            {
                totalWeight += part.Value["ArmorValue"] / 0.5;
            }
            return totalWeight;
        }
    }
}


    

