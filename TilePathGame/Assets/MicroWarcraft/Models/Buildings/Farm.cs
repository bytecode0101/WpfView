using Assets.MicroWarcraft.Models.Builders;
using Assets.MicroWarcraft.Models.Capabilities;
using Assets.MicroWarcraft.Utils;

namespace Assets.MicroWarcraft.Models.Buildings
{
    public class Farm : AbstractBuilding
    {
        public Farm()
        {
            UnitsCapabilities = new ObservableCollection<AbstractBuildingCapability>();
            UnitsCapabilities.Add(new BuildPeasantCapability());
            Name = "FARM";
            State = State.UNDER_CONSTRUCTION;
            builder = new SimpleBuilder();
        }
    }
}