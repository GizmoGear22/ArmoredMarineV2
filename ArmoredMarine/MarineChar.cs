using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
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
        public Weapons MainWeapon { get; set; }
        public Weapons SideWeapon { get; set; }
        public Weapons MeleeWeapon { get; set; }


        public Dictionary<string, int> ArmorPoints = new Dictionary<string, int>
            {
                {"head", 80 },
                {"torso", 130 },
                {"leftpauldron", 110 },
                {"rightpauldron", 110 },
                {"leftarm", 100 },
                {"rightarm", 100 },
                {"leftleg", 100 },
                {"rightleg", 100 }
            };

        

        public enum MainStats
        {
            Strength,
            Agility,
            Resilience,
            Perception
        }

        public void InsertMainWeapon()
        {
            MainWeapon = new Weapons.BoltRifle();
        }

        public void ReduceHealth(int damage)
        {
            Health -= damage;
        }

        public void ReduceArmor(int damage, string target)
        {
            ArmorPoints[target] -= damage;
        }

        public double RangedAccuracyCalc(double Perception, double Range, double Weapon = 1, double Upgrade = 1)
        {
            var PerceptionBonus = (2*Perception)/(2*Perception+5);
            var Aim = PerceptionBonus * Weapon * Upgrade * Range;
            return Aim;
        }
        public void DealRangedDamage(double range, MarineChar defender, MarineChar attacker, string aimedTarget)
        {
            //bool[]ShotSuccess = new bool[Weapon.ShotsPerRound];
            for (int i = 0; i < attacker.MainWeapon.ShotsPerRound; i++)
            {
                double ShotChance = RangedAccuracyCalc(attacker.Perception, range, attacker.MainWeapon.Accuracy) * 100;
                if (HelperFunctions.RandomNumber(100) < ShotChance && defender.ArmorPoints[aimedTarget] > 0)
                {
                    defender.ReduceArmor(attacker.MainWeapon.Damage, aimedTarget);
                    Console.WriteLine($"Dealt {attacker.MainWeapon.Damage} damage to {aimedTarget}");
                } else if (HelperFunctions.RandomNumber(100) < ShotChance && defender.ArmorPoints[aimedTarget] == 0)
                {
                    defender.ReduceHealth(attacker.MainWeapon.Damage);
                    Console.WriteLine($"Dealt {attacker.MainWeapon.Damage}");
                } else
                {
                    Console.WriteLine("Missed!");
                }
                attacker.MainWeapon.Ammo -= 1;
            }
                /*
                
                double RandomizedNumber = HelperFunctions.RandomNumber(100);
                if (RandomizedNumber > 0 && RandomizedNumber < ShotChance)
                { 
                    ShotSuccess[i] = true;
                } else
                {
                    ShotSuccess[i] = false;
                }
                Weapon.Ammo -= 1;
            }
            foreach (bool item in ShotSuccess)
            {
                if (item == true)
                {
                    defender.ReduceHealth(Weapon.Damage);
                    Console.WriteLine($"Dealt {Weapon.Damage} damage");
                } else { Console.WriteLine("Missed!"); }
            }
            */

        }
    }
}


    

