using Assets.MicroWarcraft.Models.Builders;
using Assets.MicroWarcraft.Models.Capabilities;
using Assets.MicroWarcraft.Utils;

namespace Assets.MicroWarcraft.Models.Buildings
{
    public class BowWorkshop : AbstractBuilding
    {
        public BowWorkshop()
        {
            UnitsCapabilities = new ObservableCollection<AbstractBuildingCapability>();
            UnitsCapabilities.Add(new BuildArcherCapability());
            Name = "BowWorkshop";
            State = State.UNDER_CONSTRUCTION;
            builder = new DoubleTimeBuilder();
        }
    }
}