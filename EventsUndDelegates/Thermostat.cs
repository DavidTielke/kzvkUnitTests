using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsUndDelegates
{
    public class Thermostat : IGeraet
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
            }
        }

        public void Messen(double temp)
        {
            Temperatur = temp;
        }
    }
}
