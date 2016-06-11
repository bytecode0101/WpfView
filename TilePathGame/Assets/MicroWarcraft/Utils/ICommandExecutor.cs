using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MicroWarcraft.Utils
{
    public interface ICommandExecutor
    {
        void AddSomeWork(string workItem);
        void Init();
    }
}
