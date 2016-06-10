using MyWarcraft.Models.Buildings;

namespace MyWarcraft.Models.Capabilities
{
    public class BuildBarrackCapability : AbstractBuildingCapability
    {
        public BuildBarrackCapability()
        {
            Description = "builds a barrack";
            Name = "Barrack";
        }

        public override AbstractBuildable CreateComponent()
        {
            return new Barrack();
        }
    }
}