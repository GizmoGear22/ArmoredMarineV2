using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    public class MainWeapons
    {
        public string Name { get; protected set; }
        public int Ammo { get; set; }
        public double Accuracy { get; protected set; }
        public int Damage { get; protected set; }
        public int Cost { get; protected set; }
        public int ShotsPerRound { get; protected set; }

        public enum WeaponChoices
        {
            BoltRifle,
            AutoBoltRifle,
            PlasmaRifle,
            MeltaGun
        }

        public class BoltRifle : MainWeapons, IWeapons
        {
            public BoltRifle()
            {
                Name = "BoltRifle";
                Ammo = 40;
                Accuracy = 0.6;
                Damage = 10;
                Cost = 300;
                ShotsPerRound = 10;
            }
            public double RangedAccuracyCalc(double Perception, double Range, double ArmorTarget, double Weapon = 1, double Upgrade = 1)
            {
                var PerceptionBonus = (2 * Perception) / (2 * Perception + 5);
                var Aim = PerceptionBonus * Weapon * Upgrade * Range * ArmorTarget;
                return Aim;
            }
            public void DealRangedDamage(double range, MarineChar defender, MarineChar attacker, string aimedTarget)
            {
                for (int i = 0; i < attacker.MainWeapon.ShotsPerRound; i++)
                {
                    double ShotChance = RangedAccuracyCalc(attacker.Perception, range, defender.ArmorPoints[aimedTarget]["AccuracyMod"], attacker.MainWeapon.Accuracy) * 100;
                    var Randomness = HelperFunctions.RandomNumber(100);
                    Console.WriteLine(Randomness.ToString());
                    if (Randomness < ShotChance && defender.ArmorPoints[aimedTarget]["ArmorValue"] > 0)
                    {
                        defender.ReduceArmor(attacker.MainWeapon.Damage, aimedTarget);
                        Console.WriteLine($"Dealt {attacker.MainWeapon.Damage} damage to {aimedTarget}");
                    }
                    else if (Randomness < ShotChance && defender.ArmorPoints[aimedTarget]["ArmorValue"] == 0)
                    {
                        defender.ReduceHealth(attacker.MainWeapon.Damage);
                        Console.WriteLine($"Dealt {attacker.MainWeapon.Damage} damage to health");
                    }
                    else
                    {
                        Console.WriteLine("Missed!");
                    }
                    attacker.MainWeapon.Ammo -= 1;
                }
            }
        }

        public class AutoBoltRifle : MainWeapons, IWeapons
        {
            public AutoBoltRifle()
            {
                Name = "AutoBoltRifle";
                Ammo = 40;
                Accuracy = 0.5;
                Damage = 10;
                Cost = 400;
                ShotsPerRound = 10;
            }

            public void DealRangedDamage(double range, MarineChar defender, MarineChar attacker, string aimedTarget)
            {
                int counter = 0;
                for (int i = 0; i < attacker.MainWeapon.ShotsPerRound; i++)
                {
                    double ShotChance = RangedAccuracyCalc(attacker.Perception, range, defender.ArmorPoints[aimedTarget]["AccuracyMod"], attacker.MainWeapon.Accuracy) * 100;
                    var Randomness = HelperFunctions.RandomNumber(100);
                    Console.WriteLine(Randomness.ToString());
                    if (Randomness < ShotChance && defender.ArmorPoints[aimedTarget]["ArmorValue"] > 0)
                    {
                        defender.ReduceArmor(attacker.MainWeapon.Damage, aimedTarget);
                        Console.WriteLine($"Dealt {attacker.MainWeapon.Damage} damage to {aimedTarget}");
                    }
                    else if (Randomness < ShotChance && defender.ArmorPoints[aimedTarget]["ArmorValue"] == 0)
                    {
                        defender.ReduceHealth(attacker.MainWeapon.Damage);
                        Console.WriteLine($"Dealt {attacker.MainWeapon.Damage} damage to health");
                    }
                    else if (Ammo == 0)
                    {
                        Console.WriteLine("You need to reload");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Missed!");
                        counter += 1;
                    }
                    attacker.MainWeapon.Ammo -= 1;
                }
                if (counter > 0 ) 
                {
                    for (int i = 0; i<=counter; i++)
                    {
                        double ShotChance = RangedAccuracyCalc(attacker.Perception, range, defender.ArmorPoints[aimedTarget]["AccuracyMod"], attacker.MainWeapon.Accuracy) * 100;
                        var Randomness = HelperFunctions.RandomNumber(100);
                        Console.WriteLine(Randomness.ToString());
                        if (Randomness < ShotChance && defender.ArmorPoints[aimedTarget]["ArmorValue"] > 0)
                        {
                            defender.ReduceArmor(attacker.MainWeapon.Damage, aimedTarget);
                            Console.WriteLine($"Dealt {attacker.MainWeapon.Damage} damage to {aimedTarget}");
                        }
                        else if (Randomness < ShotChance && defender.ArmorPoints[aimedTarget]["ArmorValue"] == 0)
                        {
                            defender.ReduceHealth(attacker.MainWeapon.Damage);
                            Console.WriteLine($"Dealt {attacker.MainWeapon.Damage} damage to health");
                        } else if (Ammo == 0)
                        {
                            Console.WriteLine("You need to reload");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Missed!");
                        }
                        attacker.MainWeapon.Ammo -= 1;
                    }
                }
            }

            public double RangedAccuracyCalc(double Perception, double Range, double ArmorTarget, double Weapon = 1, double Upgrade = 1)
            {
                var PerceptionBonus = (2 * Perception) / (2 * Perception + 5);
                var Aim = PerceptionBonus * Weapon * Upgrade * Range * ArmorTarget;
                return Aim;
            }

        }
    }
}
