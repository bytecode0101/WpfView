using System;

namespace MyWarcraft.Models.Events
{
    public delegate void BuildingStarted(object sender, BuildingStartedEventArgs e);

    public class BuildingStartedEventArgs : EventArgs
    {
        public AbstractBuildable Component { get; set; }
    }
}
