using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsUndDelegates.Adapter
{
    public interface IDateTimeAdapter
    {
        DateTime Now { get; }
    }

    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
