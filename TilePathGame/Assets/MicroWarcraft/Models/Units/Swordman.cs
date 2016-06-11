using Assets.MicroWarcraft.Models.Builders;

namespace  Assets.MicroWarcraft.Models.Units
{
    public class Swordman : AbstractUnit
    {
        public Swordman()
        {
            Name = "Swordman";
            State = State.UNDER_CONSTRUCTION;
            builder = new SimpleBuilder();
        }
    }
}