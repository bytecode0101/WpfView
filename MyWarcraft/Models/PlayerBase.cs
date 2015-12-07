using Microsoft.Practices.Prism.Mvvm;
using MyWarcraft.Models.Buildings;
using System.Collections.ObjectModel;

namespace MyWarcraft.Models
{
    public class PlayerBase : BindableBase
    {
        public ObservableCollection<AbstractBuildable> Components
        {
            get; set;
        }

        public AbstractBuildable SelectedComponent
        {
            get; set;
        }

        public PlayerBase()
        {
            Components = new ObservableCollection<AbstractBuildable>();
            var farm1 = new Farm();
            farm1.Position.X = 100;
            farm1.Position.Y = 100;
            var farm2 = new Farm();
            farm2.Position.X = 200;
            farm2.Position.Y = 200;
            Components.Add(farm1);
            Components.Add(farm2);
            farm1.StartBuilding();
            farm2.StartBuilding();
        }

        public void AddComponent(AbstractBuildable component)
        {
            Components.Add(component);
        }
    }
}