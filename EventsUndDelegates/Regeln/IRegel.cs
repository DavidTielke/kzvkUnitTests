using EventsUndDelegates.Ger�te;

namespace EventsUndDelegates.Regeln
{
    public interface IRegel
    {
        bool SollAngewendetWerden(IGer�t ger�t);
        void Anwenden();
    }
}