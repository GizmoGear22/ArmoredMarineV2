using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    public interface IWeapons : IWeight
    {
        string Name { get; }
        double Accuracy { get; }
        int Damage { get; }
        int Cost { get; }
        int ShotsPerRound { get; }
        int Ammo { get; set; }
        double Weight { get; }

        double RangedAccuracyCalc(double Perception, double Range, double ArmorTarget, double Weapon = 1, double Upgrade = 1);
        void DealRangedDamage(double range, MarineChar defender, MarineChar attacker, string aimedTarget);



    }
}
