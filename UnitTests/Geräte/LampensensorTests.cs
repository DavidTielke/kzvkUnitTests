using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsUndDelegates.Geräte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Geräte
{
    [TestClass]
    public class LampensensorTests
    {

        [TestMethod]
        public void Ctor_Initialize_Initialized()
        {
            var lampensensor = new Lampenaktor();

            Assert.IsNotNull(lampensensor);
        }

        [TestMethod]
        public void Einschalten_Ausgeschaltet_Eingeschaltet()
        {
            var lampe = new Lampenaktor();

            lampe.Einschalten();

            Assert.AreEqual(true, lampe.Eingeschaltet);
        }

        [TestMethod]
        public void Ausschalten_Eingeschaltet_Ausgeschaltet()
        {
            var lampe = new Lampenaktor();
            lampe.Einschalten();

            lampe.Ausschalten();

            Assert.AreEqual(false, lampe.Eingeschaltet);
        }

        [TestMethod]
        public void Einschalten_Eingeschaltet_Eingeschaltet()
        {
            var lampe = new Lampenaktor();
            lampe.Einschalten();

            lampe.Einschalten();

            Assert.AreEqual(true, lampe.Eingeschaltet);
        }

        [TestMethod]
        public void Einschalten_Ausgeschaltet_EventFeuert()
        {
            var isRaised = false;
            var lampe = new Lampenaktor();
            lampe.Zustandgeaendert += s => isRaised = true;

            lampe.Einschalten();

            Assert.IsTrue(isRaised);
        }

        [TestMethod]
        public void Ausschalten_Eingeschaltet_EventFeuert()
        {
            var isRaised = false;
            var lampe = new Lampenaktor();
            lampe.Einschalten();
            lampe.Zustandgeaendert += s => isRaised = true;

            lampe.Ausschalten();

            Assert.IsTrue(isRaised);
        }

        [TestMethod]
        public void Einschalten_Eingeschaltet_EventFeuertNichtErneut()
        {
            var isRaised = false;
            var lampe = new Lampenaktor();
            lampe.Einschalten();
            lampe.Zustandgeaendert += g => isRaised = true;

            lampe.Einschalten();
            
            Assert.IsFalse(isRaised);
        }

        [TestMethod]
        public void Ausschalten_Ausgeschaltet_EventFeuertNichtErneut()
        {
            var isRaised = false;
            var lampe = new Lampenaktor();
            lampe.Ausschalten();
            lampe.Zustandgeaendert += g => isRaised = true;

            lampe.Ausschalten();

            Assert.IsFalse(isRaised);
        }

        [TestMethod]
        public void Intensität_Ausgeschaltet_EingeschaltetMitIntensität100()
        {
            var lampe = new Lampenaktor();

            lampe.Einschalten();

            Assert.AreEqual(100, lampe.Intensität);
        }

        [TestMethod]
        public void Intensität_Eingeschaltet_AusgeschaltetMitIntensität0()
        {
            var lampe = new Lampenaktor();

            lampe.Ausschalten();

            Assert.AreEqual(0, lampe.Intensität);
        }

        [TestMethod]
        public void Dimmen_Ausgeschaltet_EingeschaltetMitIntensität10()
        {
            var lampe = new Lampenaktor();

            lampe.Dimmen(10);

            Assert.AreEqual(10, lampe.Intensität);
        }

        [TestMethod]
        public void Dimmen_Eingeschaltet_AusgeschaltetMitIntensität0()
        {
            var lampe = new Lampenaktor();
            lampe.Dimmen(10);

            lampe.Dimmen(-10);

            Assert.AreEqual(0, lampe.Intensität);
        }

        [TestMethod]
        public void Dimmen_Ausgeschaltet_Eingeschaltet()
        {
            var lampe = new Lampenaktor();

            lampe.Dimmen(10);

            Assert.IsTrue(lampe.Eingeschaltet);
        }

        [TestMethod]
        public void Dimmen_EingeschaltetMitIntensität10_Ausgeschaltet()
        {
            var lampe = new Lampenaktor();
            lampe.Dimmen(10);

            lampe.Dimmen(-10);

            Assert.IsFalse(lampe.Eingeschaltet);
        }

        [TestMethod]
        public void Dimmen_Ausgeschaltet_Ausgeschaltet()
        {
            var lampe = new Lampenaktor();

            lampe.Dimmen(-10);

            Assert.AreEqual(0, lampe.Intensität);
        }

        [TestMethod]
        public void Dimmen_Eingeschaltet_IntensitätPlus10()
        {
            var lampe = new Lampenaktor();
            lampe.Dimmen(100);

            lampe.Dimmen(10);

            Assert.AreEqual(100, lampe.Intensität);
        }
    }
}
