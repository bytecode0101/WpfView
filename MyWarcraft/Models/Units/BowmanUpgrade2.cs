﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWarcraft.Models.Units;

namespace MyWarcraft.Models.Units
{
    public class BowmanUpgrade2:DecoratorUnit
    {
        public BowmanUpgrade2(BowmanUpgrade1 farmer)
        {
            Unit = farmer;
            Life = farmer.Life + extraLife;
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
