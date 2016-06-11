using Assets.MicroWarcraft.ViewModels;
using System;

namespace Assets.MicroWarcraft.Models.Events
{
    public delegate void ComponentSelected(object sender, ComponentSelectedEventArgs e);
   
    public class ComponentSelectedEventArgs : EventArgs
    {
        public ComponentViewModel ComponentVM { get; set; }
    }
}
