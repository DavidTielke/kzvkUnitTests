using System;
using EventsUndDelegates.Geräte;
using EventsUndDelegates.Regeln;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Regeln
{
    [TestClass]
    public class LampeGesteuertVonTasterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_TasterNull_Exception()
        {
            var lampe = new Lampenaktor();
            var regel = new LampeGesteuertVonTaster(lampe, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_LampensensorNull_Exception()
        {
            var taster = new Schalter();
            var regel = new LampeGesteuertVonTaster(null, taster);
        }

        [TestMethod]
        public void SollAngewendetWerden_ÜbergebenesGerätGleich_WirdAngewendet()
        {
            var taster = new Schalter();
            var lampensensor = new Lampenaktor();
            var regel = new LampeGesteuertVonTaster(lampensensor,taster);

            var sollAngewendetWerden = regel.SollAngewendetWerden(taster);

            Assert.IsTrue(sollAngewendetWerden);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SollAngewendetWerden_NullÜbergeben_FalseWirdZurückgegeben()
        {
            var taster = new Schalter();
            var lampensensor = new Lampenaktor();
            var regel = new LampeGesteuertVonTaster(lampensensor, taster);

            regel.SollAngewendetWerden(null);
        }
    }
}
