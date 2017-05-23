using System;
using System.Data;
using EventsUndDelegates.Ger�te;

namespace EventsUndDelegates.Regeln
{
    public class TemperaturRunterWennFensterAuf : IRegel
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

        public bool SollAngewendetWerden(IGer�t ger�t)
        {
            if (ger�t == null)
            {
                throw new NullReferenceException(nameof(ger�t));
            }
            return ger�t == _fenstersensor;
        }

        public void Anwenden()
        {
            if (_fenstersensor.Status == FensterStatus.Ge�ffnet
                && _fenstersensor.LetzterStatus == FensterStatus.Geschlossen)
            {
                _urTemperatur = _tempmesser.Temperatur;
                _tempmesser.Temperatur = 16;
            }

            if (_fenstersensor.Status == FensterStatus.Geschlossen
                && _fenstersensor.LetzterStatus == FensterStatus.Ge�ffnet)
            {
                _tempmesser.Temperatur = _urTemperatur;
                _urTemperatur = 0;
            }
        }
    }
}