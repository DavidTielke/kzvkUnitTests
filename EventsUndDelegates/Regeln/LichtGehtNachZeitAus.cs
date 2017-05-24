using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using EventsUndDelegates.Geräte;

namespace EventsUndDelegates.Regeln
{
    class LichtGehtNachZeitAus : RegelBase
    {
        private readonly Lampenaktor _lampenaktor;
        private readonly Schalter _schalter;
        private DateTime _einschaltZeit;
        
        public LichtGehtNachZeitAus(Lampenaktor lampenaktor, Schalter schalter)
        {
            if (lampenaktor == null)
            {
                throw new ArgumentNullException(nameof(lampenaktor));
            }
            if (schalter == null)
            {
                throw new ArgumentNullException(nameof(schalter));
            }
            _lampenaktor = lampenaktor;
            _schalter = schalter;
        }

        public override bool SollAngewendetWerden(IGerät gerät)
        {
            if (gerät == null)
            {
                throw new NullReferenceException(nameof(gerät));
            }
            if (gerät == _schalter)
            {
                return true;
            }
            if (gerät is Zeitgeber)
            {
                if (_einschaltZeit.AddSeconds(10) <= DateTime.Now && _lampenaktor.Eingeschaltet)
                {
                    return true;
                }
            }
            return false;
        }

        public override void Anwenden()
        {
            if (!_lampenaktor.Eingeschaltet)
            {
                _lampenaktor.Einschalten();
                _einschaltZeit = DateTime.Now;
            }
            else
            {
                _lampenaktor.Ausschalten();
            }
        }
    }
}
