﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWarcraft.Models.Units
{
    class SwordManUpgrade2 : DecoratorUnit
    {
       
        public SwordManUpgrade2(SwordManUpgrade1 unit) 
        {
            Unit = unit;
            Life = unit.Life;
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }


        public override void Move(Point destination)
        {
            throw new NotImplementedException();
        }
    }
}
