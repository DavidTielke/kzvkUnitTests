using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Adapter;
using EventsUndDelegates.Geräte;
using EventsUndDelegates.Regeln;

namespace EventsUndDelegates
{
    class Program
    {

        static void Main(string[] args)
        {
            var zenti = new Zentrale();

            var tempmesser = new Thermostat();
            tempmesser.Name = "HZWZAlex";
            tempmesser.Temperatur = 23;
            zenti.Anmelden(tempmesser);

            var fenstersensor = new Fenstersensor();
            fenstersensor.Name = "FSWZAlex";
            zenti.Anmelden(fenstersensor);

            var zeitgeber = new Zeitgeber();
            zenti.Anmelden(zeitgeber);
            
            var wohnzimmerRegel = new TemperaturRunterWennFensterAuf(fenstersensor, tempmesser);
            zenti.RegelHinzufügen(wohnzimmerRegel);


            //fenstersensor.Kippen();
            //fenstersensor.Schließen();

            var von = DateTime.Now;
            var bis = DateTime.Now.AddSeconds(10);
            var zeitregel = new ZeitgesteuerteTemperatur(tempmesser, von, bis, 16, new DateTimeAdapter());
            zenti.RegelHinzufügen(zeitregel);

            Console.ReadKey();
        }
    }
}
