using System;

namespace  Assets.MicroWarcraft.Models.Events
{
    public delegate void PercentageBuilt(object sender, PercentageBuiltEventArgs e);

    public class PercentageBuiltEventArgs : EventArgs
    {
        public int Percentage { get; set; }
    }
}
