using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Adapter;
using EventsUndDelegates.Geräte;

namespace EventsUndDelegates.Regeln
{
    public class ZeitgesteuerteTemperatur : RegelBase
    {
        private readonly IDateTimeAdapter _dateTimeAdapter;

        public ZeitgesteuerteTemperatur(Thermostat thermostat, DateTime von, DateTime bis, double temperatur, IDateTimeAdapter dateTimeAdapter)
        {
            _dateTimeAdapter = dateTimeAdapter;
            Von = von;
            Bis = bis;
            Temperatur = temperatur;
            Thermostat = thermostat;
        }

        public DateTime Von { get; }
        public DateTime Bis { get; }
        public double Temperatur { get; }
        public Thermostat Thermostat { get; }
        internal double UrTemperatur { get; set; }
        public bool TempGeändert { get; set; }

        public override bool SollAngewendetWerden(IGerät gerät) => gerät is Zeitgeber;

        public override void Anwenden()
        {
            var wurdeUrTempSchonGesetzt = Thermostat.Temperatur == Temperatur;
            var istInZeitraum = _dateTimeAdapter.Now >= Von && _dateTimeAdapter.Now <= Bis;
            if (istInZeitraum && !wurdeUrTempSchonGesetzt)
            {
                UrTemperatur = Thermostat.Temperatur;
                Thermostat.Temperatur = Temperatur;
                TempGeändert = true;
            }

            if (!istInZeitraum && TempGeändert)
            {
                Thermostat.Temperatur = UrTemperatur;
                UrTemperatur = Temperatur;
                TempGeändert = false;
            }
        }
    }
}
