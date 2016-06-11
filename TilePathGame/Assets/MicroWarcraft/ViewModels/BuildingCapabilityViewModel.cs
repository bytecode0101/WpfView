using Assets.MicroWarcraft.Models.Capabilities;
using Assets.MicroWarcraft.Utils;

namespace Assets.MicroWarcraft.ViewModels
{
    public class BuildingCapabilityViewModel : BindableBase
    {
        public AbstractBuildingCapability BuildCapability { get; set; }
        public ICommand StartBuilding { get; protected set; }

        public BuildingCapabilityViewModel(AbstractBuildingCapability buildCapability)
        {
            BuildCapability = buildCapability;
            StartBuilding = new DelegateCommand<object>(Build);
        }

        private void Build(object obj)
        {
            BuildCapability.Build();
        }
    }

}
