using System;
using EventsUndDelegates.Geräte;
using EventsUndDelegates.Regeln;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Regeln
{
    [TestClass]
    public class TemperaturRunterWennFensterAufTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_ThermostatNull_Exception()
        {
            var fenstersensor = new Fenstersensor();
            var regel = new TemperaturRunterWennFensterAuf(fenstersensor, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_FenstersensorNull_Exception()
        {
            var thermostat = new Thermostat();
            var regel = new TemperaturRunterWennFensterAuf(null, thermostat);
        }

        [TestMethod]
        public void SollAngewendetWerden_ÜbergebenesGerätGleich_WirdAngewendet()
        {
            var thermostat = new Thermostat();
            var fenstersensor = new Fenstersensor();
            var regel = new TemperaturRunterWennFensterAuf(fenstersensor, thermostat);

            var sollAngewendetWerden = regel.SollAngewendetWerden(fenstersensor);

            Assert.IsTrue(sollAngewendetWerden);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SollAngewendetWerden_NullÜbergeben_FalseWirdZurückgegeben()
        {
            var thermostat = new Thermostat();
            var fenstersensor = new Fenstersensor();
            var regel = new TemperaturRunterWennFensterAuf(fenstersensor, thermostat);

            regel.SollAngewendetWerden(null);
        }

        [TestMethod]
        public void Anwenden_FensterStatusNichtGeschlossen_TemperaturAuf16()
        {
            var thermostat = new Thermostat();
            var fenstersensor = new Fenstersensor();
            var regel = new TemperaturRunterWennFensterAuf(fenstersensor, thermostat);
            fenstersensor.Öffnen();

            regel.Anwenden();

            Assert.AreEqual(16, thermostat.Temperatur);
        }

        [TestMethod]
        public void Anwenden_FensterStatusGeöffnet_GeschlossenUndAusgangsTemperatur()
        {
            var thermostat = new Thermostat();
            thermostat.Temperatur = 23;
            var fenstersensor = new Fenstersensor();
            var regel = new TemperaturRunterWennFensterAuf(fenstersensor,thermostat);
            fenstersensor.Öffnen();
            regel.Anwenden();
            fenstersensor.Schließen();

            regel.Anwenden();

            Assert.AreEqual(23, thermostat.Temperatur);
        }

        [TestMethod]
        public void Anwenden_FensterStatusGeschlossen_GeschlossenUndAusgangsTemperatur()
        {
            var thermostat = new Thermostat();
            thermostat.Temperatur = 23;
            var fenstersensor = new Fenstersensor();
            var regel = new TemperaturRunterWennFensterAuf(fenstersensor, thermostat);

            fenstersensor.Öffnen();
            regel.Anwenden();
            fenstersensor.Kippen();
            regel.Anwenden();
            fenstersensor.Öffnen();
            regel.Anwenden();
            fenstersensor.Schließen();
            regel.Anwenden();

            Assert.AreEqual(23, thermostat.Temperatur);


        }
        
    }
}
