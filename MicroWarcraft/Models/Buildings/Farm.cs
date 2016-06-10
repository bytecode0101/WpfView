using MyWarcraft.Models.Builders;
using MyWarcraft.Models.Buildings;
using MyWarcraft.Models.Capabilities;
using System.Collections.ObjectModel;

namespace MyWarcraft.Models.Buildings
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