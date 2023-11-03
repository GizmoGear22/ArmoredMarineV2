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
        public double Weight { get; protected set; }

        public enum WeaponChoices
        {
            BoltRifle,
            AutoBoltRifle,
            PlasmaRifle,
            MeltaGun
        }

        public double AccuracyCalculation(double Perception, double Range, double ArmorTarget, double Weapon = 1, double Upgrade = 1)
        {
            var PerceptionBonus = (2 * Perception) / (2 * Perception + 5);
            var Aim = PerceptionBonus * Weapon * Upgrade * Range * ArmorTarget;
            return Aim;
        }

        public static double RangeToAimPercentage(double range)
        {
            double RangeAimAdjust = (range + 30) / (2 * range);
            return RangeAimAdjust;
        }

        public class BoltRifle : MainWeapons, IWeapons, IWeight
        {

            public BoltRifle()
            {
                Name = "BoltRifle";
                Ammo = 40;
                Accuracy = 0.9;
                Damage = 10;
                Cost = 300;
                ShotsPerRound = 10;
                Weight = 10;
            }
            public void DealRangedDamage(double range, MarineCharacterManager defender, MarineCharacterManager attacker, string ArmorPartTarget)
            {
                double PercentRange = RangeToAimPercentage(range);
                for (int i = 0; i < attacker.MainWeapon.ShotsPerRound; i++)
                {
                    double ShotHitChance = AccuracyCalculation(attacker.Perception, PercentRange, defender.ArmorPoints[ArmorPartTarget]["AccuracyModifier"], attacker.MainWeapon.Accuracy) * 100;
                    var Randomness = HelperFunctions.RandomNumber(100, MarineCharacterManager.RandomNum);
                    Console.WriteLine(Randomness.ToString());
                    if (Randomness < ShotHitChance && defender.ArmorPoints[ArmorPartTarget]["ArmorValue"] > 0)
                    {
                        defender.ReduceArmor(attacker.MainWeapon.Damage, ArmorPartTarget);
                        Console.WriteLine($"Dealt {attacker.MainWeapon.Damage} damage to {ArmorPartTarget}");
                    }
                    else if (Randomness < ShotHitChance && defender.ArmorPoints[ArmorPartTarget]["ArmorValue"] <= 0)
                    {
                        defender.ArmorPoints[ArmorPartTarget]["ArmorValue"] = 0;
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

            public double GetWeight()
            {
                return Weight;
            }
        }

        public class AutoBoltRifle : MainWeapons, IWeapons, IWeight
        {
            public AutoBoltRifle()
            {
                Name = "AutoBoltRifle";
                Ammo = 40;
                Accuracy = 0.8;
                Damage = 10;
                Cost = 400;
                ShotsPerRound = 10;
                Weight = 20;
            }

            public void DealRangedDamage(double range, MarineCharacterManager defender, MarineCharacterManager attacker, string aimedTarget)
            {
                int counter = 0;
                for (int i = 0; i < attacker.MainWeapon.ShotsPerRound; i++)
                {
                    double ShotChance = AccuracyCalculation(attacker.Perception, range, defender.ArmorPoints[aimedTarget]["AccuracyModifier"], attacker.MainWeapon.Accuracy) * 100;
                    var Randomness = HelperFunctions.RandomNumber(100, MarineCharacterManager.RandomNum);
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
                        double ShotChance = AccuracyCalculation(attacker.Perception, range, defender.ArmorPoints[aimedTarget]["AccuracyModifier"], attacker.MainWeapon.Accuracy) * 100;
                        var Randomness = HelperFunctions.RandomNumber(100, MarineCharacterManager.RandomNum);
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

            public double GetWeight()
            {
                return Weight;
            }



        }
    }
}
