using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWarcraft.Models.Units;

namespace MyWarcraft.Models
{
    public class Attack : IOrder
    {
        public AbstractUnit Unit { get; set; }
        public AbstractUnit Target;
        public void Execute()
        {

        }
    }
}
