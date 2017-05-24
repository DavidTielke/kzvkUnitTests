using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Geräte;

namespace UnitTests.Stubs
{
    class GerätStub : GerätBase
    {
        public void EventAuslösen()
        {
            base.OnZustandgeaendert();
        }
    }
}
