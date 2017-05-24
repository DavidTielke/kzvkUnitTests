using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsUndDelegates.Logging
{
    public class LogSchreiber : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("Log.txt", message + Environment.NewLine);
        }
    }
}
