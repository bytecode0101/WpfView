using Microsoft.Practices.Prism.Mvvm;
using System;
using System.ComponentModel;

namespace MyWarcraft.ViewModels
{
    public class Position: BindableBase
    {
        private int x;
        private int y;

        public int X
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
    }
}