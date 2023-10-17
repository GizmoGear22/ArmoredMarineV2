﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    interface IMarine
    {
        void InsertMainWeapon();
        void ReduceHealth(int damage);
        void ReduceArmor(int damage, string target);

    }
}