using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyWarcraft.Models.Units
{
    public class MoverB : AbstractMover
    {
        internal double ypex;

        public MoverB(double rap)
        {
            ypex = rap;
        }

        internal override void T_elapsed(object sender, ElapsedEventArgs e)
        {
            if (finalx > unit.Position.X)
            {
                unit.Position.X++;
                double k = Math.Round((double)((finaly - starty) * (unit.Position.X - startx) / (finalx - startx)));
                unit.Position.Y = starty + (int)k;
            }
            else if (finalx < unit.Position.X)
            {
                unit.Position.X--;
                double k = Math.Round((double)((finaly - starty) * (unit.Position.X - startx) / (finalx - startx)));
                unit.Position.Y = starty + (int)k;
            }
            else if(finalx == unit.Position.X)
            {
                t.Stop();
                unit.State = State.READY;
            }
        }
    }
}
