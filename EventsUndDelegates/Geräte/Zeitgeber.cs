using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EventsUndDelegates.Geräte
{
    public class Zeitgeber : GerätBase
    {
        private Timer _timer;

        public Zeitgeber()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += TimerOnElapsed;
            _timer.Enabled = true;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            OnZustandgeaendert();
        }
    }
}
