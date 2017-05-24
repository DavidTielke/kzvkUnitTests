using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Geräte;
using EventsUndDelegates.Regeln;

namespace UnitTests.Stubs
{
    class RegelStub : RegelBase
    {
        public bool WurdeAngewendet { get; set; }
        public bool WirdAngewendet { get; set; } = true;
        
        public override bool SollAngewendetWerden(IGerät gerät)
        {
            return WirdAngewendet;
        }

        public override void Anwenden()
        {
            WurdeAngewendet = true;
        }
    }
}
