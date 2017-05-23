using System;
using System.Collections.Generic;
using EventsUndDelegates.Regeln;

namespace EventsUndDelegates.Geräte
{
    public class Zentrale
    {
        public List<IGerät> Geräte { get; }
        public List<IRegel> Regeln { get;  }

        public Zentrale()
        {
            Geräte = new List<IGerät>();
            Regeln = new List<IRegel>();
        }

        public void Anmelden(IGerät gerät)
        {
            var alreadyAssigned = Geräte.Contains(gerät);
            if (alreadyAssigned)
            {
                throw new InvalidOperationException("Gerät bereits angemeldet.");
            }

            this.Geräte.Add(gerät);
            gerät.Zustandgeaendert += GeraetOnZustandgeaendert;
        }

        private void GeraetOnZustandgeaendert(IGerät gerät)
        {
            foreach (var regel in Regeln)
            {
                var sollAngewendetWerden = regel.SollAngewendetWerden(gerät);
                if (sollAngewendetWerden)
                {
                    regel.Anwenden();
                }
            }
        }

        public void RegelHinzufügen(IRegel regel)
        {
            var regelBereitsVorhanden = Regeln.Contains(regel);
            if (regelBereitsVorhanden)
            {
                throw new InvalidOperationException("Regel bereits vorhanden");
            }

            Regeln.Add(regel);
        }
    }
}
