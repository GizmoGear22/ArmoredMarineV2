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

        public MarineStats MarineStats { get; set; }
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

        public double RangedAccuracyCalc(int Perception, double Range, double Weapon = 1, double Upgrade = 1)
        {
            double PerceptionBonus = Perception * 0.2;
            double Aim = PerceptionBonus * Weapon * Upgrade * Range;
            return Aim;

        }
        public void InsertMainWeapon()
        {
            MainWeapon = new Weapons.BoltRifle();
        }
        public void DealRangedDamage(Weapons Weapon, double range, int CompHealth)
        {
            bool[]ShotSuccess = new bool[Weapon.ShotsPerRound];
            for (int i = 0; i < Weapon.ShotsPerRound; i++)
            {
                double ShotChance = RangedAccuracyCalc(MarineStats.Perception, range, MainWeapon.Accuracy)*100;
                
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
                    CompHealth -= Weapon.Damage;
                    Console.WriteLine($"Dealt {Weapon.Damage} damage");
                } else { Console.WriteLine("You missed!"); }
            }

        }
    }
}


    

