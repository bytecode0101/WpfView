using MyWarcraft.Models.Events;

namespace MyWarcraft.Models.Capabilities
{
    public abstract class AbstractBuildingCapability
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public event BuildingStarted BuildingStarted;

        public AbstractBuildable Build()
        {
            var newBuildable = CreateComponent();
            newBuildable.StartBuilding();
            if (BuildingStarted != null)
            {
                BuildingStarted.Invoke(this, new BuildingStartedEventArgs() { Component = newBuildable });
            }
            return newBuildable;
        }

        public abstract AbstractBuildable CreateComponent();
    }
}