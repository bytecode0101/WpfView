using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWarcraft.Models.Movers
{
    public class UnitMove : AbstractMovement
    {
        public UnitMove()
        {
            SecondsForMovement = 10;
            SecondsForStep = 1;
        }
    }
}
