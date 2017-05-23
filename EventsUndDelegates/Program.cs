using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var fenstersensor = new Fenstersensor();
            var fenstersensor2 = new Fenstersensor();
            var tempmesser2 = new Thermostat();

            tempmesser.Name = "HZWZAlex";
            fenstersensor.Name = "FSWZAlex";
            fenstersensor2.Name = "FSSRAlex";
            tempmesser2.Name = "HZSRAlex";
            tempmesser.Temperatur = 23;
            tempmesser2.Temperatur = 23;
            
            zenti.Anmelden(tempmesser2);
            zenti.Anmelden(fenstersensor2);
            zenti.Anmelden(tempmesser);
            zenti.Anmelden(fenstersensor);

            var serverRaumRegel = new TemperaturRunterWennFensterAuf(fenstersensor2, tempmesser2);
            zenti.RegelHinzufügen(serverRaumRegel);

            var wohnzimmerRegel = new TemperaturRunterWennFensterAuf(fenstersensor, tempmesser);
            zenti.RegelHinzufügen(wohnzimmerRegel);

            fenstersensor.Kippen();
            fenstersensor.Schließen();
            Console.ReadKey();
        }


    }
}
