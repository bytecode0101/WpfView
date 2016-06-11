namespace  Assets.MicroWarcraft.Models.Builders
{
    public class SimpleBuilder : AbstractBuilder
    {
        public SimpleBuilder()
        {
            TimeForEachStep = 100;
            PercentageBuiltAtEachStep = 5;
        }
    }
}
