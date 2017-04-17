using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWarcraft.Models.Builders
{
    class SuperSlowBuilder : AbstractBuilder
    {
        public SuperSlowBuilder()
        {
            TimeForEachStep = 500;
            PercentageBuiltAtEachStep = 5;
        }
    }
}
