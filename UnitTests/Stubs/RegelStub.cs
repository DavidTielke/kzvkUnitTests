using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Geräte;
using EventsUndDelegates.Regeln;

namespace UnitTests.Stubs
{
    class RegelStub : IRegel
    {
        public bool WurdeAngewendet { get; set; }
        public bool WirdAngewendet { get; set; } = true;
        
        public bool SollAngewendetWerden(IGerät gerät)
        {
            return WirdAngewendet;
        }

        public void Anwenden()
        {
            WurdeAngewendet = true;
        }
    }
}
