using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    interface IWeapons
    {
        double Accuracy { get; }
        int Damage { get; }
        int Cost { get; }
        int ShotsPerRound { get; }
    }
}
