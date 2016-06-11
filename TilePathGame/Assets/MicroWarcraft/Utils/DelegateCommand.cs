using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MicroWarcraft.Utils
{
    //TODO: implement this class
    public class DelegateCommand <T>: ICommand
    {
        private Action<T> action;
        private Action simpleAction;

        public DelegateCommand(Action<T> action)
        {
            this.action = action;
        }

        public DelegateCommand(Action action)
        {
            this.simpleAction = action;
        }

        public virtual void Execute()
        {

        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
