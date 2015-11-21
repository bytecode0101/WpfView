using System;
using System.Collections.Generic;

namespace MyWarcraft.Models.Units
{
    public abstract class AbstractUnit : AbstractBuildable
    {
        public int Range { get; set; }
        public int AttackPower { get; set; }
        public List<IBuildable> attackers { get; set; } 

        public virtual void Attack(IBuildable target)
        {
            if ((Math.Pow((this.Position.x - target.Position.x), 2) + Math.Pow((this.Position.y - target.Position.y), 2)) > Math.Pow(this.Range, 2))
            {
                this.Move(target.Position.x, target.Position.y);
            }
            else
            {
                target.TakeHit(this, AttackPower);
            }
        }

        public virtual void Move(int x, int y)
        {
            if (x > Position.x)
            {
                x++;
            }
            else if (x < Position.x)
            {
                x--;
            }
            if (y > Position.y)
            {
                y++;
            }
            else if (y < Position.y)
            {
                y--;
            }
        }

        public override void TakeHit(AbstractUnit attacker, int power)
        {
            if (State!=State.UNDER_ATTACK)
            {
                this.Attack(attacker);                
            }
            //this.attackers.Add(attacker);
            State = State.UNDER_ATTACK;
            Life -= power;
        }
    }
}
