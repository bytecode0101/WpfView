using System;

namespace MyWarcraft.Models.Events
{
    public delegate void PercentageBuilt(object sender, PercentageBuiltEventArgs e);

    public class PercentageBuiltEventArgs : EventArgs
    {
        public int Percentage { get; set; }
    }
}
