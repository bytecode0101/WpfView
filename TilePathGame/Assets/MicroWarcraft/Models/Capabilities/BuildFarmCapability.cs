using Assets.MicroWarcraft.Models.Buildings;

namespace  Assets.MicroWarcraft.Models.Capabilities
{
    public class BuildFarmCapability : AbstractBuildingCapability
    {
        public BuildFarmCapability()
        {
            Name = "Farm";
            Description = "builds a farm";
        }

        public override AbstractBuildable CreateComponent()
        {
            return new Farm();
        }
    }
}