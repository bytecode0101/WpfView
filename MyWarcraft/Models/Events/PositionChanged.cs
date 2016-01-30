using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWarcraft.Models.Events
{
    public delegate void PositionChanged(object sender, PositionChangedEventArgs e);
    public class PositionChangedEventArgs : EventArgs
    {
        public PositionChanged Position { get; set; }
    }

    
}
