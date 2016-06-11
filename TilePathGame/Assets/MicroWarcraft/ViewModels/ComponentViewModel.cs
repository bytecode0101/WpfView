using Assets.MicroWarcraft.Models;
using Assets.MicroWarcraft.Models.Events;
using Assets.MicroWarcraft.Utils;

namespace Assets.MicroWarcraft.ViewModels
{
    public class ComponentViewModel : BindableBase
    {
        public event ComponentSelected ComponentSelected;
        public int Life { get; set; }

        public AbstractBuildable Component { get; set; }

        public ObservableCollection<BuildingCapabilityViewModel> BuildingCapabilitiesVMs { get; set; }
        public ObservableCollection<BuildingCapabilityViewModel> UnitsCapabilitiesVMs { get; set; }

        public ComponentViewModel(AbstractBuildable component)
        {
            Component = component;
            if (component.BuildingsCapabilities!=null)
            {
                BuildingCapabilitiesVMs = new ObservableCollection<BuildingCapabilityViewModel>();
                foreach (var capability in component.BuildingsCapabilities)
                {
                    var capabilityVM = new BuildingCapabilityViewModel(capability);
                    BuildingCapabilitiesVMs.Add(capabilityVM);
                }
            }
            if (component.UnitsCapabilities != null)
            {
                UnitsCapabilitiesVMs = new ObservableCollection<BuildingCapabilityViewModel>();
                foreach (var capability in component.UnitsCapabilities)
                {
                    var capabilityVM = new BuildingCapabilityViewModel(capability);
                    UnitsCapabilitiesVMs.Add(capabilityVM);
                }
            }
        }

        internal void Move(int x, int y)
        {
            Component.Move(x,y);
        }

        private void OnComponentSelected()
        {
            if (ComponentSelected!=null)
            {
                ComponentSelected.Invoke(this, new ComponentSelectedEventArgs() { ComponentVM = this});
            }
        }
    }
}
