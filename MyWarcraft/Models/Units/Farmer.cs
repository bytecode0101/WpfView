﻿using System;

namespace MyWarcraft.Models.Units
{
    public class Farmer : AbstractUnit
    {

        public Farmer(int y, int x, int life) : base(y, x, life)
        {
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


