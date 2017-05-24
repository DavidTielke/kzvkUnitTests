using System;

namespace EventsUndDelegates.Geräte
{
    public class Fenstersensor : GerätBase
    {
        private FensterStatus _status;

        public FensterStatus Status
        {
            get { return _status; }
            private set
            {
                LetzterStatus = _status;
                _status = value;
                OnZustandgeaendert();
                OnLogEvent($"Fenster: {Name} wurde {value.ToString().ToLower()}.");
            }
        }

        public FensterStatus LetzterStatus { get; private set; }

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
