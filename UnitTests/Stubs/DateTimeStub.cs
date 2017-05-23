using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Adapter;

namespace UnitTests.Stubs
{
    class DateTimeStub : IDateTimeAdapter
    {
        public DateTime Now { get; set; }
    }
}
