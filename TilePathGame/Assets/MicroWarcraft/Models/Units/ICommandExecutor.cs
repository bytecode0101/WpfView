using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MicroWarcraft.Models.Units
{
    public interface ICommandExecutor
    {
        void AddSomeWork(string workItem);
        void Init();
    }
}
