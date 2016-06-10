using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Input;
using MyWarcraft.Models;
using Microsoft.Practices.Prism.Commands;
using MyWarcraft.Models.Capabilities;

namespace MyWarcraft.ViewModels
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
