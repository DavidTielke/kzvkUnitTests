using System;
using EventsUndDelegates.Geräte;
using EventsUndDelegates.Regeln;

namespace UnitTests.Regeln
{
    internal class LampenaktorDimmenRegel : RegelBase
    {
        private Lampenaktor _lampe;
        private Schalter _schalter;

        public LampenaktorDimmenRegel(Lampenaktor lampe, Schalter schalter)
        {
            if (lampe == null)
            {
                throw new ArgumentNullException(nameof(lampe));
            }
            if (schalter == null)
            {
                throw new ArgumentNullException(nameof(schalter));
            }
            _lampe = lampe;
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
                _lampe.Intensität += 10;
            }
            else
            {
                _lampe.Intensität -= 10;
            }
        }
    }
}