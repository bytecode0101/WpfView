using Assets.MicroWarcraft.Models.Units;

namespace  Assets.MicroWarcraft.Models.Capabilities
{
    public class BuildArcherCapability : AbstractBuildingCapability
    {
        public BuildArcherCapability()
        {
            Description = "builds an archer";
            Name = "Archer";
        }

        public override AbstractBuildable CreateComponent()
        {
            return new Archer();
        }
    }
}