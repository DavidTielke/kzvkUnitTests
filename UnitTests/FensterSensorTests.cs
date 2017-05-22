using System;
using EventsUndDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class FensterSensorTests
    {
        [TestMethod]
        //          Objekt_Vorbedingung_Nachbedingung
        public void Status_Initialized_Geschlossen()
        {
            var fenstersensor = new Fenstersensor();

            Assert.AreEqual(FensterStatus.Geschlossen, fenstersensor.Status);
        }

        [TestMethod]
        public void Öffnen_StatusGeschlossen_StatusGeöffnet()
        {
            // Arange Bereich
            var fenstersensor = new Fenstersensor();

            // Act Bereich
            fenstersensor.Öffnen();

            // Assert Bereich
            Assert.AreEqual(FensterStatus.Geöffnet, fenstersensor.Status);
        }
    }
}
