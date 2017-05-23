using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Geräte;

namespace UnitTests.Stubs
{
    class GerätStub : IGerät
    {
        public string Name { get; set; }
        public event NeuerMesswertHandler Zustandgeaendert;

        public virtual void OnZustandgeaendert()
        {
            Zustandgeaendert?.Invoke(this);
        }
    }
}
