using System;

namespace EventsUndDelegates.Geräte
{
    public class Thermostat : IGerät
    {
        private double _temperatur;
        public string Name { get; set; }

        public event NeuerMesswertHandler Zustandgeaendert;

        public double Temperatur
        {
            get { return _temperatur; }
            set
            {
                _temperatur = value;
                Console.WriteLine("Die Temperatur wurde auf " + value + " Grad gesetzt");
                OnZustandgeaendert();
            }
        }

        public void Messen(double temp)
        {
            Temperatur = temp;
        }

        protected virtual void OnZustandgeaendert()
        {
            Zustandgeaendert?.Invoke(this);
        }
    }
}
