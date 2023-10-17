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
    public class MarineChar : IMarine
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

        public void InsertMainWeapon()
        {
            MainWeapon = new MainWeapons.BoltRifle();
        }

        public void ReduceHealth(int damage)
        {
            this.Health -= damage;
        }

        public void ReduceArmor(int damage, string target)
        {
            this.ArmorPoints[target]["ArmorValue"] -= damage;
        }

        public double RangedAccuracyCalc(double Perception, double Range, double ArmorTarget, double Weapon = 1, double Upgrade = 1)
        {
            var PerceptionBonus = (2*Perception)/(2*Perception+5);
            var Aim = PerceptionBonus * Weapon * Upgrade * Range * ArmorTarget;
            return Aim;
        }
        public void DealRangedDamage(double range, MarineChar defender, MarineChar attacker, string aimedTarget)
        {
            for (int i = 0; i < attacker.MainWeapon.ShotsPerRound; i++)
            {
                double ShotChance = RangedAccuracyCalc(attacker.Perception, range, defender.ArmorPoints[aimedTarget]["AccuracyMod"], attacker.MainWeapon.Accuracy) * 100;
                if (HelperFunctions.RandomNumber(100) < ShotChance && defender.ArmorPoints[aimedTarget]["ArmorValue"] > 0)
                {
                    defender.ReduceArmor(attacker.MainWeapon.Damage, aimedTarget);
                    Console.WriteLine($"Dealt {attacker.MainWeapon.Damage} damage to {aimedTarget}");
                } else if (HelperFunctions.RandomNumber(100) < ShotChance && defender.ArmorPoints[aimedTarget]["ArmorValue"] == 0)
                {
                    defender.ReduceHealth(attacker.MainWeapon.Damage);
                    Console.WriteLine($"Dealt {attacker.MainWeapon.Damage} damage to health");
                } else
                {
                    Console.WriteLine("Missed!");
                }
                attacker.MainWeapon.Ammo -= 1;
            }

        }
    }
}


    

