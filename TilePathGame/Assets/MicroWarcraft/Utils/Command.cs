using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MicroWarcraft.Utils
{
   public class Command : ICommand
    {
        public event ExecuteHandle ExecuteHandle;

        public void Execute()
        {
            if (ExecuteHandle != null)
            {
                ExecuteHandle();
            }
        }
    }
}
