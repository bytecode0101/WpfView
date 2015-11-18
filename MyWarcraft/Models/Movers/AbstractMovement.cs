using MyWarcraft.Models.Events;
using MyWarcraft.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyWarcraft.Models.Movers
{
    public abstract class AbstractMovement
    {
        public Position endPosition { get; set; }

        public event SecondsElapsed SecondsElapsed;

        public int SecondsForStep
        {
            get
            {
                return secondsForStep;
            }

            set
            {
                secondsForStep = value;
            }
        }

        public int SecondsForMovement
        {
            get
            {
                return secondsForMovement;
            }

            set
            {
                secondsForMovement = value;
            }
        }

        protected Timer timer;
        private int secondsForMovement;
        private int secondsForStep;
        private int secondsElapsed;

        /// <summary>
        /// Unit begings to Move  - movement will be finalized after timer elapses 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void StartMoving(int SecondsForMovement)
        {
            timer = new Timer();
            timer.Interval = SecondsForMovement;
            timer.Elapsed += Timer_Elapsed;
            secondsElapsed = 0;
            timer.Start();
        }

        /// <summary>
        /// Movement is finalized. Unit now has new Position coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Position Move(int x, int y)
        {
            endPosition.X = x;
            endPosition.X = y;
            return endPosition;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            secondsElapsed += SecondsForStep;
            if (SecondsElapsed != null)
            {
                SecondsElapsed.Invoke(this, new SecondsElapsedEventArgs());
            }

            if (secondsElapsed < SecondsForMovement)
            {
                timer.Start();
            }

        }
    }
}
