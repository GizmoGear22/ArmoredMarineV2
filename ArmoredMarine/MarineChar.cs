﻿using System;
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

        public void ReduceHealth(int damage)
        {
            this.Health -= damage;
        }

        public double RangedAccuracyCalc(int Perception, double Range, double Weapon = 1, double Upgrade = 1)
        {
            double PerceptionBonus = (2*Perception)/(2*Perception+5);
            double Aim = PerceptionBonus * Weapon * Upgrade * Range;
            return Aim;
        }
        public void DealRangedDamage(double range, MarineChar defender, MarineChar attacker)
        {
            //bool[]ShotSuccess = new bool[Weapon.ShotsPerRound];
            for (int i = 0; i < attacker.MainWeapon.ShotsPerRound; i++)
            {
                double ShotChance = RangedAccuracyCalc(attacker.Perception, range, attacker.MainWeapon.Accuracy) * 100;
                if (HelperFunctions.RandomNumber(100) < ShotChance)
                {
                    defender.ReduceHealth(attacker.MainWeapon.Damage);
                    Console.WriteLine($"Dealt {attacker.MainWeapon.Damage} damage");
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


    

