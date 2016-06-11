using Assets.MicroWarcraft.Models.Units;

namespace  Assets.MicroWarcraft.Models.Capabilities
{
    public class BuildSwordmanCapability : AbstractBuildingCapability
    {
        public BuildSwordmanCapability()
        {
            Description = "builds an swordman";
            Name = "Swordman";
        }

        public override AbstractBuildable CreateComponent()
        {
            return new Swordman();
        }
    }
}