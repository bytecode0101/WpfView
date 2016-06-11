using Assets.MicroWarcraft.Models.Builders;
using Assets.MicroWarcraft.Models.Capabilities;
using Assets.MicroWarcraft.Utils;

namespace Assets.MicroWarcraft.Models.Units
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

        public void Build(AbstractBuildable buildable)
        {
            PutCommand(() => {
                RealBuidBuilding(param1);
            });
        }
    }
}