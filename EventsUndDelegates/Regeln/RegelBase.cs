using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Geräte;
using EventsUndDelegates.Logging;

namespace EventsUndDelegates.Regeln
{
    public abstract class RegelBase : IRegel, IILogMessageSource
    {
        public event EventHandler<LogEventArgs> LogEvent;
        public abstract bool SollAngewendetWerden(IGerät gerät);

        public abstract void Anwenden();

        protected virtual void OnLogEvent(LogEventArgs e)
        {
            LogEvent?.Invoke(this, e);
        }
    }
}
