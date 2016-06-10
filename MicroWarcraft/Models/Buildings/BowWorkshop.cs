using MyWarcraft.Models.Builders;
using MyWarcraft.Models.Capabilities;
using System.Collections.ObjectModel;

namespace MyWarcraft.Models.Buildings
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