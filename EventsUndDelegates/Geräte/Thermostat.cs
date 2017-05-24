using System;

namespace EventsUndDelegates.Geräte
{
    public class Thermostat : GerätBase
    {
        private double _temperatur;

        public double Temperatur
        {
            get { return _temperatur; }
            set
            {
                _temperatur = value;
                OnLogEvent("Die Temperatur wurde auf " + value + " Grad gesetzt");
                OnZustandgeaendert();
            }
        }

        public void Messen(double temp)
        {
            Temperatur = temp;
        }
    }
}
