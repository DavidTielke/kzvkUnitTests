using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsUndDelegates.Geräte
{
    public class Schalter : GerätBase
    {
        private bool _eingeschaltet;

        public bool Eingeschaltet
        {
            get { return _eingeschaltet; }
            set
            {
                _eingeschaltet = value;
                var status = value ? "eingeschaltet" : "ausgeschaltet";
                OnLogEvent($"Schalter: {Name} wurde {status}.");
                OnZustandgeaendert();
            }
        }

        public void Einschalten()
        {
            Eingeschaltet = true;
        }

        public void Ausschalten()
        {
            Eingeschaltet = false;
        }

    }
}
