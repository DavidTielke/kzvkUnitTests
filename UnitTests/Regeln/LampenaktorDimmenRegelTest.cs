using System;
using EventsUndDelegates.Geräte;
using EventsUndDelegates.Regeln;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Regeln
{
    [TestClass]
    public class LampenaktorDimmenRegelTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_Intizialize_Exception()
        {
            var regel = new LampenaktorDimmenRegel(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_IntizializeLampeNull_Exception()
        {
            var schalter = new Schalter();
            var regel = new LampenaktorDimmenRegel(null, schalter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_IntizializeSchalterNull_Exception()
        {
            var lampe = new Lampenaktor();
            var regel = new LampenaktorDimmenRegel(lampe, null);
        }

        [TestMethod]
        public void SollAngewendetWerden_ÜbergebenesGerätGleich_WirdAngewendet()
        {
            var schalter = new Schalter();
            var lampe = new Lampenaktor();
            var regel = new LampenaktorDimmenRegel(lampe,schalter);

            var sollAngewendetWerden = regel.SollAngewendetWerden(schalter);

            Assert.IsTrue(sollAngewendetWerden);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SollAngewendetWerden_NullÜbergeben_FalseWirdZurückgegeben()
        {
            var lampe = new Lampenaktor();
            var schalter = new Schalter();
            var regel = new LampenaktorDimmenRegel(lampe, schalter);

            regel.SollAngewendetWerden(null);
        }

        [TestMethod]
        public void Anwenden_DimmungAuf0_DimmungAuf10()
        {
            var lampe = new Lampenaktor();
            var schalter = new Schalter();
            var regel = new LampenaktorDimmenRegel(lampe,schalter);
            schalter.Einschalten();

            regel.Anwenden();

            Assert.AreEqual(10, lampe.Intensität);
        }

        [TestMethod]
        public void Anwenden_DimmungAuf20_DimmungAuf10()
        {
            var lampe = new Lampenaktor();
            lampe.Intensität = 20;
            var schalter = new Schalter();
            var regel = new LampenaktorDimmenRegel(lampe, schalter);
            schalter.Ausschalten();

            regel.Anwenden();

            Assert.AreEqual(10, lampe.Intensität);
        }

        [TestMethod]
        public void Anwenden_DimmungAuf0_DimmunAuf0()
        {
            var lampe = new Lampenaktor();
            var schalter = new Schalter();
            var regel = new LampenaktorDimmenRegel(lampe, schalter);
            schalter.Ausschalten();

            regel.Anwenden();

            Assert.AreEqual(0, lampe.Intensität);
        }

        [TestMethod]
        public void Anwenden_DimmungAuf100_DimmungAuf100()
        {
            var lampe = new Lampenaktor();
            lampe.Intensität = 100;
            var schalter = new Schalter();
            var regel = new LampenaktorDimmenRegel(lampe, schalter);
            schalter.Einschalten();

            regel.Anwenden();

            Assert.AreEqual(100, lampe.Intensität);
        }

        [TestMethod]
        public void Anwenden_DimmungAuf30_DimmungAuf30()
        {
            var lampe = new Lampenaktor();
            lampe.Intensität = 30;
            var schalter = new Schalter();
            var regel = new LampenaktorDimmenRegel(lampe, schalter);
            schalter.Einschalten();
            regel.Anwenden();

            schalter.Ausschalten();
            regel.Anwenden();

            Assert.AreEqual(30, lampe.Intensität);
        }

    }
}
