using System;

namespace EventsUndDelegates.Logging
{
    public class LogEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}