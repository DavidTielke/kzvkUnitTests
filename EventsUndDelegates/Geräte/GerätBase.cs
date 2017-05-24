using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Logging;

namespace EventsUndDelegates.Geräte
{
    public abstract class GerätBase : IGerät, IILogMessageSource
    {
        public event EventHandler<LogEventArgs> LogEvent;
        public string Name { get; set; }
        public event NeuerMesswertHandler Zustandgeaendert;

        protected virtual void OnLogEvent(string message)
        {
            var args = new LogEventArgs
            {
                Message = message
            };

            LogEvent?.Invoke(this, args);
        }

        protected virtual void OnZustandgeaendert()
        {
            Zustandgeaendert?.Invoke(this);
        }
    }
}
