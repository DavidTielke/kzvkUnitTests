using System;
using EventsUndDelegates.Geräte;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Stubs;

namespace UnitTests.Geräte
{
    [TestClass]
    public class ZentraleTests
    {
        [TestMethod]
        public void Ctor_Uninitialized_0Regeln()
        {
            var zentrale = new Zentrale();

            Assert.AreEqual(0, zentrale.Regeln.Count);
        }
        
        [TestMethod]
        public void Ctor_Uninitialized_0Geräte()
        {
            var zentrale = new Zentrale();

            Assert.AreEqual(0, zentrale.Geräte.Count);
        }

        [TestMethod]
        public void Anmelden_GerätNichtListe_GerätInDerListe()
        {
            var zentrale = new Zentrale();
            var gerät = new Fenstersensor();

            zentrale.Anmelden(gerät);

            Assert.AreEqual(1, zentrale.Geräte.Count);
            CollectionAssert.Contains(zentrale.Geräte, gerät);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Anmelden_GerätInListe_Exception()
        {
            var zentrale = new Zentrale();
            var gerät = new GerätStub();
            zentrale.Anmelden(gerät);

            zentrale.Anmelden(gerät);
        }


        [TestMethod]
        public void RegelHinzufügen_RegelNichtListe_RegelInDerListe()
        {
            var zentrale = new Zentrale();
            var regel = new RegelStub();

            zentrale.RegelHinzufügen(regel);

            Assert.AreEqual(1, zentrale.Regeln.Count);
            CollectionAssert.Contains(zentrale.Regeln, regel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegelHinzufügen_RegelInListe_Exception()
        {
            var zentrale = new Zentrale();
            var regel = new RegelStub();
            zentrale.RegelHinzufügen(regel);

            zentrale.RegelHinzufügen(regel);
        }

        [TestMethod]
        public void Zustandgeändert_GerätUndRegelHinzugefügt_RegelWirdAngewandt()
        {
            var zentrale = new Zentrale();
            var gerät = new GerätStub();
            var regel = new RegelStub();
            zentrale.Anmelden(gerät);
            zentrale.RegelHinzufügen(regel);

            gerät.EventAuslösen();

            Assert.IsTrue(regel.WurdeAngewendet);
        }

        [TestMethod]
        public void Zustandgeändert_RegelSollNichtAngewendetWerden_RegelWirdNichtAngewendet()
        {
            var zentrale = new Zentrale();
            var gerät = new GerätStub();
            var regel = new RegelStub();
            regel.WirdAngewendet = false;
            zentrale.Anmelden(gerät);
            zentrale.RegelHinzufügen(regel);

            gerät.EventAuslösen();

            Assert.IsFalse(regel.WurdeAngewendet);
        }

        [TestMethod]
        public void Zustandgeändert_KeineRegelHinzugefügt_Exception()
        {
            var zentrale = new Zentrale();
            var gerät = new GerätStub();
            zentrale.Anmelden(gerät);

            gerät.EventAuslösen();
        }
    }
}
