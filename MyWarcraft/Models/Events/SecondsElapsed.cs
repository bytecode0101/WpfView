using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWarcraft.Models.Events
{
    public delegate void SecondsElapsed(object sender, SecondsElapsedEventArgs e);

    public class SecondsElapsedEventArgs : EventArgs
    {
        public int Seconds { get; set; }
    }


}
