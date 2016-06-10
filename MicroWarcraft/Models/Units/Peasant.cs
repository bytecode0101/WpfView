using MyWarcraft.Models.Builders;
using MyWarcraft.Models.Capabilities;
using System.Collections.ObjectModel;

namespace MyWarcraft.Models.Units
{
    public class Peasant : AbstractUnit
    {
        public Peasant()
        {
            BuildingsCapabilities = new ObservableCollection<AbstractBuildingCapability>();
            BuildingsCapabilities.Add(new BuildFarmCapability());
            BuildingsCapabilities.Add(new BuildBarrackCapability());
            Name = "Peasant";
            State = State.UNDER_CONSTRUCTION;
            builder = new SimpleBuilder();
        }
    }
}