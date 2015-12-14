using System;
using System.Collections.Generic;
//using System.Threading;
using System.Timers;

namespace MyWarcraft.Models.Units
{
    public abstract class AbstractUnit : AbstractBuildable
    {
        //public int a, b;
        public int Range { get; set; }
        public int AttackPower { get; set; }
        public List<IBuildable> attackers { get; set; }
        public AbstractMover mover;

        public virtual void Attack(AbstractBuildable target)
        {
            if ((Math.Pow((this.Position.X - target.Position.X), 2) + Math.Pow((this.Position.Y - target.Position.Y), 2)) > Math.Pow(this.Range, 2))
            {
                this.Move(target.Position.X, target.Position.Y);
            }
            else
            {
                target.TakeHit(this, AttackPower);
            }
        }

        internal override void Move(int x, int y)
        {
            if (this.State != State.UNDER_CONSTRUCTION)
            {
                if (this.State == State.MOVING)
                {
                    mover.Stop();
                }
                if (Math.Abs(Position.X - x) < Math.Abs(Position.Y - y))
                {
                    double rap = (Math.Abs(Position.X - x) / Math.Abs(Position.Y - y));
                    mover = new MoverA(rap);
                }
                else
                {
                    double rap = (Math.Abs(Position.Y - y) / Math.Abs(Position.X - x));
                    mover = new MoverB(rap);
                }
                mover.Move(this, x, y);
            }
            //a = (int)Math.Round((double)(finalx - Position.X)/100);
            //b = (int)Math.Round((double)(finaly - Position.Y)/100);        
        }



        //private void T_elapsed2(object sender, ElapsedEventArgs e)
        //{            
        //    if (finalx > Position.X)
        //    {
        //        Position.X+=a;
        //    }
        //    else if (finalx < Position.X)
        //    {
        //        Position.X+=a;
        //    }
        //    if (finaly > Position.Y)
        //    {
        //        Position.Y+=b;
        //    }
        //    else if (finaly < Position.Y)
        //    {
        //        Position.Y+=b;
        //    }
        //    if ((Math.Abs(finalx - Position.X)<40) && (Math.Abs(finaly - Position.Y)<40))
        //    {
        //        t.Stop();
        //    }
        //}

        public override void TakeHit(AbstractUnit attacker, int power)
        {
            if (State != State.UNDER_ATTACK)
            {
                this.Attack(attacker);
            }
            //this.attackers.Add(attacker);
            State = State.UNDER_ATTACK;
            Life -= power;
        }
    }
}
