using MyWarcraft.Models.Units;

namespace MyWarcraft.Models.Capabilities
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