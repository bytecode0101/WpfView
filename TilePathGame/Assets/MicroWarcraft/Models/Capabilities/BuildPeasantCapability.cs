using Assets.MicroWarcraft.Models.Units;

namespace  Assets.MicroWarcraft.Models.Capabilities
{
    public class BuildPeasantCapability : AbstractBuildingCapability
    {
        public BuildPeasantCapability()
        {
            Name = "Peasant";
            Description = "Builds a peasant.";
        }

        public override AbstractBuildable CreateComponent()
        {
            return new Peasant();
        }
    }
}