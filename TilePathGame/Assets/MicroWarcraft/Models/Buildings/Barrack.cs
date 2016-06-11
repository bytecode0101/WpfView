using Assets.MicroWarcraft.Models.Builders;
using Assets.MicroWarcraft.Models.Capabilities;
using Assets.MicroWarcraft.Utils;

namespace Assets.MicroWarcraft.Models.Buildings
{
    public class Barrack : AbstractBuilding
    {
        public Barrack()
        {
            BuildingsCapabilities = new ObservableCollection<AbstractBuildingCapability>();
            UnitsCapabilities = new ObservableCollection<AbstractBuildingCapability>();
            BuildingsCapabilities.Add(new BuildBowWorkshopCapability());
            UnitsCapabilities.Add(new BuildSwordmanCapability());
            Name = "Barrack";
            State = State.UNDER_CONSTRUCTION;
            builder = new DoubleTimeBuilder();
        }
    }
}
