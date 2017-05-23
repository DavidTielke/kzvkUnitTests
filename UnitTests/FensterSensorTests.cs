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

        [TestMethod]
        public void Kippen_StatusGeschlossen_StatusGeöffnet()
        {
            var fenstersensor = new Fenstersensor();

            fenstersensor.Kippen();

            Assert.AreEqual(FensterStatus.Gekippt, fenstersensor.Status);
        }

        [TestMethod]
        public void Schließen_StatusGeöffnet_StatusGeschlossen()
        {
            var fenstersensor = new Fenstersensor();
            fenstersensor.Öffnen();

            fenstersensor.Schließen();

            Assert.AreEqual(FensterStatus.Geschlossen, fenstersensor.Status);
        }

        [TestMethod]
        public void Name_NameUninitialized_NameIsTest()
        {
            var fenstersensor = new Fenstersensor();

            fenstersensor.Name = "Test";

            Assert.AreEqual("Test", fenstersensor.Name);
        }


        [TestMethod]
        public void Öffnen_Geschlossen_ZustandAusgelöst()
        {
            var raised = false;
            var fenstersensor = new Fenstersensor();
            fenstersensor.Zustandgeaendert += s => raised = true;

            fenstersensor.Öffnen();

            Assert.IsTrue(raised);
        }


        [TestMethod]
        public void Kippen_Geschlossen_ZustandZweiMalAusgelöst()
        {
            var eventCounter = 0;
            var fenstersensor = new Fenstersensor();
            fenstersensor.Zustandgeaendert += s => eventCounter++;

            fenstersensor.Kippen();

            Assert.AreEqual(2, eventCounter);
        }

        [TestMethod]
        public void Kippen_Geschlossen_AbfolgeOffenGekippt()
        {
            string events = "";
            var fensterstensor = new Fenstersensor();
            fensterstensor.Zustandgeaendert += s => events += ((Fenstersensor)s).Status.ToString();

            fensterstensor.Kippen();

            Assert.AreEqual("GeöffnetGekippt", events);
        }
        [TestMethod]
        public void Schließen_Gekippt_ZustandZweiMalAusgelöst()
        {
            var eventCounter = 0;
            var fenstersensor = new Fenstersensor();
            fenstersensor.Kippen();
            fenstersensor.Zustandgeaendert += s => eventCounter++;

            fenstersensor.Schließen();

            Assert.AreEqual(2, eventCounter);
        }

        [TestMethod]
        public void Schließen_Gekippt_AbfolgeGekipptGeschlossen()
        {
            string events = "";
            var fensterstensor = new Fenstersensor();
            fensterstensor.Kippen();
            fensterstensor.Zustandgeaendert += 
                s => events += ((Fenstersensor)s).Status.ToString();

            fensterstensor.Schließen();

            Assert.AreEqual("GeöffnetGeschlossen", events);
        }
    }
}
