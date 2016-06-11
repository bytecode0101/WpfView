using Assets.MicroWarcraft.Models;
using Assets.MicroWarcraft.Models.Events;
using Assets.MicroWarcraft.Utils;

namespace Assets.MicroWarcraft.ViewModels
{
    public class BoardViewModel : BindableBase
    {
        private ObservableCollection<AbstractBuildable> components { get; set; }
        public ObservableCollection<ComponentViewModel> ComponentVMs { get; set; }
        private ComponentViewModel selectedComponent;

        public ComponentViewModel SelectedComponent
        {
            get
            {
                return selectedComponent;
            }

            set
            {
                selectedComponent = value;
                OnPropertyChanged("SelectedComponent");
            }
        }

        public BoardViewModel(ObservableCollection<AbstractBuildable> components)
        {
            this.components = components;
            ComponentVMs = new ObservableCollection<ComponentViewModel>();
            components.CollectionChanged += Components_CollectionChanged;
            foreach (var component in components)
            {
                var componentVM = new ComponentViewModel(component);
                componentVM.ComponentSelected += ComponentVM_ComponentSelected;
                ComponentVMs.Add(componentVM);
            }
        }

        //private void OnBoadLeftClick(IInputElement parameter)
        //{
          //TODO: if necessary
        //}

        private void ComponentVM_ComponentSelected(object sender, ComponentSelectedEventArgs e)
        {
            UnbindSelectedComponentCapabilities();
            SelectedComponent = e.ComponentVM;
            BindSelectedComponentCapabilities();
        }

        private void BindSelectedComponentCapabilities()
        {
            if (selectedComponent != null && selectedComponent.Component != null)
            {
                if (selectedComponent.Component.BuildingsCapabilities != null)
                {
                    foreach (var capability in selectedComponent.Component.BuildingsCapabilities)
                    {
                        capability.BuildingStarted += Capability_BuildingStarted;
                    }
                }
                if (selectedComponent.Component.UnitsCapabilities != null)
                {
                    foreach (var capability in selectedComponent.Component.UnitsCapabilities)
                    {
                        capability.BuildingStarted += Capability_BuildingStarted;
                    }
                }
            }
        }

        private void Capability_BuildingStarted(object sender, Models.Events.BuildingStartedEventArgs e)
        {
            var component = e.Component;
            components.Add(component);
        }

        private void UnbindSelectedComponentCapabilities()
        {
            if (selectedComponent != null && selectedComponent.Component != null)
            {
                if (selectedComponent.Component.BuildingsCapabilities != null)
                {
                    foreach (var capability in selectedComponent.Component.BuildingsCapabilities)
                    {
                        capability.BuildingStarted -= Capability_BuildingStarted;
                    }
                }
                if (selectedComponent.Component.UnitsCapabilities != null)
                {
                    foreach (var capability in selectedComponent.Component.UnitsCapabilities)
                    {
                        capability.BuildingStarted -= Capability_BuildingStarted;
                    }
                }
            }
        }

        private void Components_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (var item in e.NewItems)
            {
                var componentVM = new ComponentViewModel((AbstractBuildable)item);
                componentVM.ComponentSelected += ComponentVM_ComponentSelected;
                ComponentVMs.Add(componentVM);
            }
        }
    }
}
