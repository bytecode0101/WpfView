using MyWarcraft.Models.Events;
using System.Timers;

namespace MyWarcraft.Models.Builders
{
    public class AbstractBuilder
    {
        public event PercentageBuilt PercentageBuilt;

        protected Timer timer;
        private int percentageBuiltAtEachStep;
        private int timeForEachStep;
        private int percentageBuilt;

        public int PercentageBuiltAtEachStep
        {
            get
            {
                return percentageBuiltAtEachStep;
            }

            set
            {
                percentageBuiltAtEachStep = value;
            }
        }

        public int TimeForEachStep
        {
            get
            {
                return timeForEachStep;
            }

            set
            {
                timeForEachStep = value;
            }
        }

        public virtual void StartBuilding()
        {
            timer = new Timer();
            timer.Interval = timeForEachStep;
            timer.Elapsed += Timer_Elapsed;
            percentageBuilt = 0;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            percentageBuilt += percentageBuiltAtEachStep;
            if (PercentageBuilt != null)
            {
                PercentageBuilt.Invoke(this, new PercentageBuiltEventArgs() { Percentage = percentageBuilt > 100 ? 100 : percentageBuilt });
            }
            if(percentageBuilt < 100)
            {
                timer.Start();
            }
        }
    }
}
