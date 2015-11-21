using Microsoft.Practices.Prism.Mvvm;
using System;
using System.ComponentModel;

namespace MyWarcraft.ViewModels
{
    public class Position: BindableBase, INotifyPropertyChanged
    {
        private int x;
        private int y;

        public event PropertyChangingEventHandler PositionChanged;

        public int X { get; set; }
        
        public string propertyName
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        public Position(int X, int Y)
        {
            this.x = X;
            this.y = Y;
        }

        

        public void OnPropertyChanged(int propertyName)
        {
            PropertyChangingEventHandler handle = PositionChanged;
            if (PositionChanged!=null)
            {
                handle(this, new PropertyChangedEventArgs());
            }
        }

    }
}