using MyWarcraft.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWarcraft.Models
{
    public interface IOrder
    {
        AbstractUnit Unit { get; set; }
        void Execute();
    }
}
