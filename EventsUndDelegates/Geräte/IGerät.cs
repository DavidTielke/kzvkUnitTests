namespace EventsUndDelegates.Geräte
{
    public interface IGerät
    {
        string Name { get; set; }

        event NeuerMesswertHandler Zustandgeaendert;
    } 
}
