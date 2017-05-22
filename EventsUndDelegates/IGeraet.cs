using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsUndDelegates
{
    public interface IGeraet
    {
        string Name { get; set; }

        event NeuerMesswertHandler Zustandgeaendert;
    } 
}
