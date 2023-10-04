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
                {"Head", 80 },
                {"Torso", 130 },
                {"LeftPauldron", 110 },
                {"RightPauldron", 110 },
                {"LeftArm", 100 },
                {"RightArm", 100 },
                {"LeftLeg", 100 },
                {"RightLeg", 100 }

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

        public double RangedAccuracyCalc(int Perception, double Range, double Weapon = 1, double Upgrade = 1)
        {
            double PerceptionBonus = Perception * 0.2;
            double Aim = PerceptionBonus * Weapon * Upgrade * Range;
            return Aim;
        }
        public void DealRangedDamage(Weapons Weapon, double range, int opponentHealth, int Perception)
        {
            bool[]ShotSuccess = new bool[Weapon.ShotsPerRound];
            for (int i = 0; i < Weapon.ShotsPerRound; i++)
            {
                double ShotChance = RangedAccuracyCalc(Perception, range, MainWeapon.Accuracy)*100;
                
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
                    opponentHealth -= Weapon.Damage;
                    Console.WriteLine($"Dealt {Weapon.Damage} damage");
                } else { Console.WriteLine("Missed!"); }
            }

        }
    }
}


    

