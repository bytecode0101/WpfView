using MyWarcraft.Models.Builders;

namespace MyWarcraft.Models.Units
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