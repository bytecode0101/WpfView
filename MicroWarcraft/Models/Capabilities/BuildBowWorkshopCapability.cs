using MyWarcraft.Models.Buildings;

namespace MyWarcraft.Models.Capabilities
{
    public class BuildBowWorkshopCapability : AbstractBuildingCapability
    {
        public BuildBowWorkshopCapability()
        {
            Description = "builds a BowWorkshop";
            Name = "BowWorkshop";
        }

        public override AbstractBuildable CreateComponent()
        {
            return new BowWorkshop();
        }
    }
}