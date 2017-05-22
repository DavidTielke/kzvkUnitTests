using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EventsUndDelegates
{
    public class Zentrale
    {
        private List<IGeraet> _angemeldeteGeraete;
        public List<IRegel> Regeln { get; set; }

        public Zentrale()
        {
            this._angemeldeteGeraete = new List<IGeraet>();
            Regeln = new List<IRegel>();
        }
        public void Anmelden(IGeraet geraet)
        {           
            this._angemeldeteGeraete.Add(geraet);
            geraet.Zustandgeaendert += GeraetOnZustandgeaendert;
        }

        private void GeraetOnZustandgeaendert(IGeraet gerät)
        {
            foreach (var regel in Regeln)
            {
                var sollAngewendetWerden = regel.SollAngewendetWerden(gerät);
                if (sollAngewendetWerden)
                {
                    regel.Anwenden();
                }
            }
        }

        public void RegelHinzufügen(IRegel regel)
        {
            Regeln.Add(regel);
        }
    }

    public interface IRegel
    {
        bool SollAngewendetWerden(IGeraet gerät);
        void Anwenden();
    }

    public class TemperaturRunterWennFensterAuf : IRegel
    {
        private readonly Fenstersensor _fenstersensor;
        private readonly Thermostat _tempmesser;
        private double _urTemperatur;

        public TemperaturRunterWennFensterAuf(Fenstersensor fenstersensor, Thermostat tempmesser)
        {
            _fenstersensor = fenstersensor;
            _tempmesser = tempmesser;
        }

        public bool SollAngewendetWerden(IGeraet gerät)
        {
            return gerät == _fenstersensor;
        }

        public void Anwenden()
        {
            if (_fenstersensor.Status != FensterStatus.Geschlossen)
            {
                _urTemperatur = _tempmesser.Temperatur;
                _tempmesser.Temperatur = 16;
            }
            else
            {
                _tempmesser.Temperatur = _urTemperatur;
            }
        }
    }


}
