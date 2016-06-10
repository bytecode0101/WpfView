using MyWarcraft.Models;
using MyWarcraft.Models.Builders;
using MyWarcraft.Models.Capabilities;
using System.Collections.ObjectModel;

namespace MyWarcraft.Models.Buildings
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
