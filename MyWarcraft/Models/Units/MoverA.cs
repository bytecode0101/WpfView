using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyWarcraft.Models.Units
{
    public class MoverA : AbstractMover
    {
        internal double xpey;

        public MoverA(double rap)
        {
            xpey = rap;
        }

        internal override void T_elapsed(object sender, ElapsedEventArgs e)
        {
            //if (finalx > unit.Position.X)
            //{
            //    unit.Position.X++;
            //}
            //else if (finalx < unit.Position.X)
            //{
            //    unit.Position.X--;
            //}
            if (finaly > unit.Position.Y)
            {
                unit.Position.Y++;
                double k= Math.Round((double)((finalx - startx) * (unit.Position.Y - starty) / (finaly - starty)));
                unit.Position.X = startx + (int)k;
            }
            else if (finaly < unit.Position.Y)
            {
                unit.Position.Y--;
                double k = Math.Round((double)((finalx - startx) * (unit.Position.Y - starty) / (finaly - starty)));
                unit.Position.X = startx + (int)k;
            }
            if (finaly == unit.Position.Y)
            {
                t.Stop();
            }
        }
    }
}
