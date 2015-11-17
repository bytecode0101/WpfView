using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWarcraft.Models.Units;

namespace MyWarcraft.Models
{
    public class Move : IOrder
    {
        public AbstractUnit Unit { get; set; }
        public Point Target;
        public void Execute()
        {
            Unit.Move(Target.x, Target.y);
        }
    }
}
