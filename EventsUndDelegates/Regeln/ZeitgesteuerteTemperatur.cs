using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Adapter;
using EventsUndDelegates.Geräte;

namespace EventsUndDelegates.Regeln
{
    public class ZeitgesteuerteTemperatur : IRegel
    {
        private readonly IDateTimeAdapter _dateTimeAdapter;

        public ZeitgesteuerteTemperatur(DateTime von, DateTime bis, decimal temperatur, IDateTimeAdapter dateTimeAdapter)
        {
            _dateTimeAdapter = dateTimeAdapter;
            Von = von;
            Bis = bis;
            Temperatur = temperatur;
        }

        public DateTime Von { get; }
        public DateTime Bis { get; }
        public decimal Temperatur { get; set; }

        public bool SollAngewendetWerden(IGerät gerät)
        {
            return _dateTimeAdapter.Now >= Von && _dateTimeAdapter.Now <= Bis;
        }

        public void Anwenden()
        {

        }
    }
}
