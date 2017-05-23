using System;

namespace EventsUndDelegates.Geräte
{
    public class Fenstersensor : IGerät
    {
        private FensterStatus _status;
        public string Name { get; set; }

        public FensterStatus Status
        {
            get { return _status; }
            private set
            {
                LetzterStatus = _status;
                _status = value;
                OnZustandgeaendert();
                Console.WriteLine($"Fenster: {Name} wurde {value.ToString().ToLower()}.");
            }
        }

        public FensterStatus LetzterStatus { get; private set; }


        public event NeuerMesswertHandler Zustandgeaendert;

        protected virtual void OnZustandgeaendert()
        {
            this.Zustandgeaendert?.Invoke(this);
        }

        public void Kippen()
        {
            if (Status == FensterStatus.Geschlossen)
            {
                Öffnen();
            }

            Status = FensterStatus.Gekippt;
        }

        public void Öffnen()
        {
            Status = FensterStatus.Geöffnet;
        }

        public void Schließen()
        {
            if (Status == FensterStatus.Gekippt)
            {
                Öffnen();
            }

            Status = FensterStatus.Geschlossen;
        }
    }
}
