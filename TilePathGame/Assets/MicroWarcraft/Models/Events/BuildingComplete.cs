using System;

namespace  Assets.MicroWarcraft.Models.Events
{
    public delegate void BuildingComplete(object sender, BuildingCompleteEventArgs e);
   
    public class BuildingCompleteEventArgs : EventArgs
    {
        public AbstractBuildable Component { get; set; }
    }
}
