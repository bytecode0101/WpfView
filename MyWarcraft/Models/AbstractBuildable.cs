﻿using Microsoft.Practices.Prism.Mvvm;
using MyWarcraft.Models.Builders;
using MyWarcraft.Models.Capabilities;
using MyWarcraft.Models.Events;
using NLog;
using System.Collections.ObjectModel;

namespace MyWarcraft.Models
{
    public abstract class AbstractBuildable : BindableBase, IBuildable
    {
        public event BuildingComplete BuildingComplete;

        public ObservableCollection<AbstractBuildingCapability> BuildingsCapabilities { get; set; }
        public ObservableCollection<AbstractBuildingCapability> UnitsCapabilities { get; set; }

        public string Name { get; set; }

        public int PercentageBuilt
        {
            get
            {
                return percentageBuilt;
            }

            set
            {
                percentageBuilt = value;
                OnPropertyChanged("PercentageBuilt");
            }
        }

        public State State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                OnPropertyChanged("State");
            }

        }
        public Health Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
                OnPropertyChanged("Health");
            }

        }
        protected AbstractBuilder builder;

        protected Logger Log;

        private int percentageBuilt;
        private State state;
        private Health health;

        #region Constructor
        public AbstractBuildable()
        {
            Log = LogManager.GetLogger(GetType().FullName);
        } 
        #endregion


        public virtual void Ready(int percentage)
        {
            if (percentage == 100)
            {
                OnBuildComplete();
            }

            if (percentage != 100)
            {
                OnDamaged();
            }
        }

        protected void OnBuildComplete()
        {
            State = State.READY;
            if (BuildingComplete != null)
            {
                var arg = new BuildingCompleteEventArgs();
                arg.Component = this;
                BuildingComplete.Invoke(this, arg);
            }
        }
        protected void OnDamaged()
        {
            Health = Health.DAMAGED;
                ;
            if (BuildingComplete != null)
            {
                var arg = new BuildingCompleteEventArgs();
                arg.Component = this;
                BuildingComplete.Invoke(this, arg);
            }
        }
        public virtual void StartBuilding()
        {
            builder.PercentageBuilt += Builder_PercentageBuilt;
            builder.StartBuilding();
        }

        private void Builder_PercentageBuilt(object sender, PercentageBuiltEventArgs e)
        {
            PercentageBuilt = e.Percentage;
            if (PercentageBuilt >= 100)
            {
                OnBuildComplete();
            }
        }
    }
}
