using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Adapter;
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

        [TestInitialize]
        public void Initialize()
        {
            _von = new DateTime(2017, 05, 23, 14, 0, 0);
            _bis = new DateTime(2017, 05, 23, 15, 0, 0);
            _temp = 16;
            _dateTimeStub = new DateTimeStub();

            _zeitRegel = new ZeitgesteuerteTemperatur(_von, _bis, _temp, _dateTimeStub);
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
        public void SollAngewendetWerden_JetztInBereich_Anwenden()
        {
            _dateTimeStub.Now = new DateTime(2017, 05, 23, 14, 30, 0);

            var anwenden = _zeitRegel.SollAngewendetWerden(null);

            Assert.IsTrue(anwenden);
        }

        [TestMethod]
        public void SollAngewendetWerden_JetztAufUntererGrenze_Anwenden()
        {
            _dateTimeStub.Now = new DateTime(2017, 05, 23, 14, 0, 0);

            var anwenden = _zeitRegel.SollAngewendetWerden(null);

            Assert.IsTrue(anwenden);
        }

        [TestMethod]
        public void SollAngewendetWerden_JetztAufObererGrenze_Anwenden()
        {
            _dateTimeStub.Now = new DateTime(2017, 05, 23, 15, 0, 0);

            var anwenden = _zeitRegel.SollAngewendetWerden(null);

            Assert.IsTrue(anwenden);
        }


        [TestMethod]
        public void SollAngewendetWerden_JetztNichtInBereich_NichtAnwenden()
        {
            _dateTimeStub.Now = new DateTime(2017, 05, 23, 15, 30, 0);

            var anwenden = _zeitRegel.SollAngewendetWerden(null);

            Assert.IsFalse(anwenden);
        }
    }
}
