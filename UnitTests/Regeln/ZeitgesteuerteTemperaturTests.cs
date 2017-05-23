using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Adapter;
using EventsUndDelegates.Geräte;
using EventsUndDelegates.Regeln;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Stubs;

namespace UnitTests.Regeln
{
    [TestClass]
    public class ZeitgesteuerteTemperaturTests
    {
        private ZeitgesteuerteTemperatur _zeitRegel;
        private DateTime _von;
        private DateTime _bis;
        private int _temp;
        private DateTimeStub _dateTimeStub;
        private Thermostat _thermostat;
        private int _urTemp;

        [TestInitialize]
        public void Initialize()
        {
            _von = new DateTime(2017, 05, 23, 14, 0, 0);
            _bis = new DateTime(2017, 05, 23, 15, 0, 0);
            _temp = 16;
            _urTemp = 23;
            _dateTimeStub = new DateTimeStub();
            _thermostat = new Thermostat();
            _thermostat.Temperatur = _urTemp;

            _zeitRegel = new ZeitgesteuerteTemperatur(_thermostat, _von, _bis, _temp, _dateTimeStub);
        }

        [TestMethod]
        public void Ctor_Initialized_VonGesetzt()
        {
            Assert.AreEqual(_von, _zeitRegel.Von);
        }
        
        [TestMethod]
        public void Ctor_Initialized_BisGesetzt()
        {
            Assert.AreEqual(_bis, _zeitRegel.Bis);
        }

        [TestMethod]
        public void Ctor_Initialized_TempGesetzt()
        {
            Assert.AreEqual(_temp, _zeitRegel.Temperatur);
        }

        [TestMethod]
        public void Ctor_Initialized_ThermostatGesetzt()
        {
            Assert.AreEqual(_thermostat, _zeitRegel.Thermostat);
        }

        [TestMethod]
        public void SollAngewendetWerden_SenderIstZeitgeber_Anwenden()
        {
            var zeitgeber = new Zeitgeber();

            var anwenden = _zeitRegel.SollAngewendetWerden(zeitgeber);

            Assert.IsTrue(anwenden);
        }

        [TestMethod]
        public void SollAngewendetWerden_SenderNichtZeitgeber_NichtAnwenden()
        {
            var fenstersensor = new Fenstersensor();

            var anwenden = _zeitRegel.SollAngewendetWerden(fenstersensor);

            Assert.IsFalse(anwenden);
        }

        [TestMethod]
        public void Anwenden_InnerhalbDerZeitOhneUr_NeueTempGesetzt()
        {
            _dateTimeStub.Now = new DateTime(2017, 05, 23, 14, 00, 00);

            _zeitRegel.Anwenden();

            Assert.AreEqual(_temp, _thermostat.Temperatur);
        }

        [TestMethod]
        public void Anwenden_InnerhalbDerZeitOhneUr_UrTempGesetzt()
        {
            _dateTimeStub.Now = new DateTime(2017, 05, 23, 14, 00, 00);

            _zeitRegel.Anwenden();

            Assert.AreEqual(_urTemp, _zeitRegel.UrTemperatur);
        }

        [TestMethod]
        public void Anwenden_ZweiMalAnwenden_UrTempNochRichtig()
        {
            _dateTimeStub.Now = new DateTime(2017, 05, 23, 14, 00, 00);

            _zeitRegel.Anwenden();
            _zeitRegel.Anwenden();

            Assert.AreEqual(_urTemp, _zeitRegel.UrTemperatur);
        }
        
        [TestMethod]
        public void Anwenden_JetztNichtIMZeitbereich_TempWirdNichtGeändert()
        {
            _dateTimeStub.Now = new DateTime(2017, 05, 23, 12, 00, 00);

            _zeitRegel.Anwenden();

            Assert.AreEqual(_urTemp, _thermostat.Temperatur);
        }
        
        [TestMethod]
        public void Anwenden_JetztNichtIMZeitbereich_UrTempWirdNichtGeändert()
        {
            _dateTimeStub.Now = new DateTime(2017, 05, 23, 12, 00, 00);

            _zeitRegel.Anwenden();

            Assert.AreNotEqual(_urTemp, _zeitRegel.UrTemperatur);
        }
        
        [TestMethod]
        public void Anwenden_AnwendenNachBereich_TempWirdZurückgesetzt()
        {
            _dateTimeStub.Now = new DateTime(2017, 05, 23, 14, 00, 00);
            _zeitRegel.Anwenden();

            _dateTimeStub.Now = new DateTime(2017, 05, 23, 15, 00, 01);
            _zeitRegel.Anwenden();

            Assert.AreEqual(_urTemp, _thermostat.Temperatur);
        }
    }
}
