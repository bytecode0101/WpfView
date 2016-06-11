using System;
using System.ComponentModel;

namespace Assets.MicroWarcraft.Utils
{
    public class BindableBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string v)
        {
            //TODO: implement the observer pattern
        }

    }
}
