using System;

namespace EventsUndDelegates.Logging
{
    public interface IILogMessageSource
    {
        event EventHandler<LogEventArgs> LogEvent;

    }
}
