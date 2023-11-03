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
    public class MarineCharacterManager : IWeight
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Resilience { get; set; }
        public int Perception { get; set; }
        public int MovementDistance { get; set; }
        public double Weight { get; set; }
        public int MaxPoints { get; set; }
        public int Credits { get; set; }
        public int CombatActions { get; set; } = 2;
        public IWeapons MainWeapon { get; set; } = null;
        public IWeapons SideWeapon { get; set; } = null;
        public IWeapons MeleeWeapon { get; set; } = null;


        public Dictionary<string, Dictionary<string, double>> ArmorPoints = new Dictionary<string, Dictionary<string, double>>
            {
                {"head", new Dictionary<string, double> { { "ArmorValue", .60 }, {"AccuracyModifier", 0.6 } } },
                {"torso", new Dictionary<string, double> { { "ArmorValue", 1.30 }, {"AccuracyModifier", 1.2 } } },
                {"leftpauldron", new Dictionary<string, double> { { "ArmorValue", 1.10 }, {"AccuracyModifier    ", 1 } } },
                {"rightpauldron", new Dictionary<string, double> { { "ArmorValue", 1.10 }, {"AccuracyModifier", 1 } } },
                {"leftarm", new Dictionary < string, double > { { "ArmorValue", .800 }, { "AccuracyModifier", 0.8 } } },
                {"rightarm", new Dictionary < string, double > { { "ArmorValue", .800 }, { "AccuracyModifier", 0.8 } } },
                {"leftleg", new Dictionary < string, double > { { "ArmorValue", .800 }, { "AccuracyModifier", 0.8 } } },
                {"rightleg", new Dictionary < string, double > { { "ArmorValue", .800 }, { "AccuracyModifier", 0.8 } } }
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

        public double ArmorWeight()
        {
            double armorWeight = 0;
            foreach (var part in ArmorPoints)
            {
                armorWeight += part.Value["ArmorValue"] / 0.65;
            }
            return armorWeight; 
        }

        public double GetWeight()
        {
            return Weight;
        }

        //Temporary Weight Calculation until I learn how to do it via interfaces. I know so little *cry*
        public void TotalWeight()
        {
            double _totalWeight = 0;
            _totalWeight += ArmorWeight();
            if (MainWeapon != null)
            {
                _totalWeight += MainWeapon.Weight;
            } else if (SideWeapon != null)
            {
                _totalWeight += SideWeapon.Weight;
            } else if (MeleeWeapon != null)
            {
                _totalWeight += MeleeWeapon.Weight;
            }
                Weight = _totalWeight;
        }

        public void PossibleMovementDistance()
        {
            var weightToMove = Weight/10;
            var agilityToMove = Agility * 10 + 10;
            MovementDistance = (int)Math.Floor(agilityToMove - weightToMove);
        }

    }
}


    

