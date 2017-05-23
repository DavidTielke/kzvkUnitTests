using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EventsUndDelegates.Geräte
{
    public class Zeitgeber : IGerät
    {
        private Timer _timer;
        public string Name { get; set; }
        public event NeuerMesswertHandler Zustandgeaendert;

        public Zeitgeber()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += TimerOnElapsed;
            _timer.Enabled = true;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            OnZustandgeaendert(this);
        }

        protected virtual void OnZustandgeaendert(IGerät gerät)
        {
            Zustandgeaendert?.Invoke(gerät);
        }
    }
}
