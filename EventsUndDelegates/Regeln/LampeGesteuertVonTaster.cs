using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Geräte;

namespace EventsUndDelegates.Regeln
{
    public class LampeGesteuertVonTaster : RegelBase
    {
        private readonly Lampenaktor _lampenaktor;
        private readonly Schalter _schalter;

        public LampeGesteuertVonTaster(Lampenaktor lampenaktor, Schalter schalter)
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
            return gerät == _schalter;
        }

        public override void Anwenden()
        {
            if (_schalter.Eingeschaltet)
            {
                _lampenaktor.Einschalten();
            }
            else
            {
                _lampenaktor.Ausschalten();
            }
        }
    }
}
