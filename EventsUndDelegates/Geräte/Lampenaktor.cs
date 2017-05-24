using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsUndDelegates.Geräte
{
    public class Lampenaktor : GerätBase
    {
        private bool _eingeschaltet;
        private double _intensität;

        public bool Eingeschaltet
        {
            get { return _eingeschaltet; }
            private set
            {
                _eingeschaltet = value;
                var status = value ? "eingeschaltet" : "ausgeschaltet";
                OnLogEvent($"Lampe: {Name} wurde {status}.");
                OnZustandgeaendert();
            }
        }

        public double Intensität
        {
            get { return _intensität; }
            set
            {
                if (value < 0)
                {
                    _intensität = 0;
                    return;
                }
                if (value > 100)
                {
                    _intensität = 100;
                    return;
                }
                _intensität = value;
            }
        }

        public void Einschalten()
        {
            if (!Eingeschaltet)
            {
                Eingeschaltet = true;
                Intensität = 100;
            }
        }

        public void Ausschalten()
        {
            if (Eingeschaltet)
            {
                Eingeschaltet = false;
                Intensität = 0;
            }
        }

        public void Dimmen(int dimmgrad)
        {
            Intensität += dimmgrad;
            if (Intensität > 0)
            {
                Eingeschaltet = true;
            }
            else
            {
                Eingeschaltet = false;
            }
        }
    }
}