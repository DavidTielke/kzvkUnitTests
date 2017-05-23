using EventsUndDelegates.Geräte;

namespace EventsUndDelegates.Regeln
{
    public interface IRegel
    {
        bool SollAngewendetWerden(IGerät gerät);
        void Anwenden();
    }
}