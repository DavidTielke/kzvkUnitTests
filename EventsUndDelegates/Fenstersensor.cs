using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsUndDelegates
{
    public class Fenstersensor : IGeraet 
    {
        public string Name { get; set; }
        public FensterStatus Status { get; set; }


        public event NeuerMesswertHandler Zustandgeaendert;

        protected virtual void OnZustandgeaendert()
        {
            this.Zustandgeaendert?.Invoke(this);
        }
         
        public void Kippen()
        {
            Status = FensterStatus.Gekippt;
            Console.WriteLine($"Fenster: {Name} wurde gekippt.");
            OnZustandgeaendert();
        }

        public void Öffnen()
        {
            Status = FensterStatus.Geöffnet;
            Console.WriteLine($"Fenster: {Name} wurde geöffnet.");
            OnZustandgeaendert();
        }

        public void Schließen()
        {
            Status = FensterStatus.Geschlossen;
            Console.WriteLine($"Fenster: {Name} wurde geschlossen.");
            OnZustandgeaendert();
        }
    }

    public delegate void NeuerMesswertHandler(IGeraet gerät);

    public enum FensterStatus
    {
        Geschlossen,
        Gekippt,
        Geöffnet
    }
}
