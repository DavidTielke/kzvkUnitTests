using System;
using System.Data;
using EventsUndDelegates.Geräte;

namespace EventsUndDelegates.Regeln
{
    public class TemperaturRunterWennFensterAuf : RegelBase
    {
        private readonly Fenstersensor _fenstersensor;
        private readonly Thermostat _tempmesser;
        private double _urTemperatur;

        public TemperaturRunterWennFensterAuf(Fenstersensor fenstersensor, Thermostat tempmesser)
        {
            if (fenstersensor == null)
            {
                throw new ArgumentNullException(nameof(fenstersensor));
            }
            if (tempmesser == null)
            {
                throw new ArgumentNullException(nameof(tempmesser));
            }
            _fenstersensor = fenstersensor;
            _tempmesser = tempmesser;
        }

        public override bool SollAngewendetWerden(IGerät gerät)
        {
            if (gerät == null)
            {
                throw new NullReferenceException(nameof(gerät));
            }
            return gerät == _fenstersensor;
        }

        public override void Anwenden()
        {
            if (_fenstersensor.Status == FensterStatus.Geöffnet
                && _fenstersensor.LetzterStatus == FensterStatus.Geschlossen)
            {
                _urTemperatur = _tempmesser.Temperatur;
                _tempmesser.Temperatur = 16;
            }

            if (_fenstersensor.Status == FensterStatus.Geschlossen
                && _fenstersensor.LetzterStatus == FensterStatus.Geöffnet)
            {
                _tempmesser.Temperatur = _urTemperatur;
                _urTemperatur = 0;
            }
        }
    }
}