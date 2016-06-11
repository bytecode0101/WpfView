using Assets.MicroWarcraft.Models.Builders;

namespace  Assets.MicroWarcraft.Models.Units
{
    public class Archer : AbstractUnit
    {
        public Archer()
        {
            Name = "Archer";
            State = State.UNDER_CONSTRUCTION;
            builder = new DoubleTimeBuilder();
        }
    }
}