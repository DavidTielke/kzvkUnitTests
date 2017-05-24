using System;
using System.Collections.Generic;
using EventsUndDelegates.Logging;
using EventsUndDelegates.Regeln;

namespace EventsUndDelegates.Geräte
{
    public class Zentrale
    {
        public List<GerätBase> Geräte { get; }
        public List<RegelBase> Regeln { get;  }
        private ILogger _logger;

        public Zentrale()
        {
            Geräte = new List<GerätBase>();
            Regeln = new List<RegelBase>();
            _logger = new ConsoleLogger();
        }

        public void Anmelden(GerätBase gerät)
        {
            var alreadyAssigned = Geräte.Contains(gerät);
            if (alreadyAssigned)
            {
                throw new InvalidOperationException("Gerät bereits angemeldet.");
            }

            this.Geräte.Add(gerät);
            gerät.Zustandgeaendert += GeraetOnZustandgeaendert;
            gerät.LogEvent += Loggen;
        }

        private void Loggen(object sender, LogEventArgs e)
        {
            _logger.Log(e.Message);
        }

        private void GeraetOnZustandgeaendert(GerätBase gerät)
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

        public void RegelHinzufügen(RegelBase regel)
        {
            var regelBereitsVorhanden = Regeln.Contains(regel);
            if (regelBereitsVorhanden)
            {
                throw new InvalidOperationException("Regel bereits vorhanden");
            }

            Regeln.Add(regel);
            regel.LogEvent += Loggen;
        }
    }
}
