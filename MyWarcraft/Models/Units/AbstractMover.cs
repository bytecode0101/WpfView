using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyWarcraft.Models.Units
{
    public class AbstractMover
    {
        public Timer t;
        internal int startx, starty, finalx, finaly;
        internal AbstractUnit unit;

        public AbstractMover()
        {
            t = new Timer();
            t.Interval = 12;
            t.Elapsed += T_elapsed;
        }

        public virtual void Move(AbstractUnit unit, int x, int y)
        {
            this.unit = unit;
            startx = unit.Position.X;
            starty = unit.Position.Y;            
            t.Start();
            unit.State = State.MOVING;
            finalx = x;
            finaly = y;
        }

        internal virtual void T_elapsed(object sender, ElapsedEventArgs e)
        {
            if (finalx > unit.Position.X)
            {
                unit.Position.X++;
            }
            else if (finalx < unit.Position.X)
            {
                unit.Position.X--;
            }
            if (finaly > unit.Position.Y)
            {
                unit.Position.Y++;
            }
            else if (finaly < unit.Position.Y)
            {
                unit.Position.Y--;
            }
            if ((finalx == unit.Position.X) && (finaly == unit.Position.Y))
            {
                t.Stop();
            }
        }

        public virtual void Stop()
        {
            t.Stop();
            unit.State = State.READY;
        }
    }
}
