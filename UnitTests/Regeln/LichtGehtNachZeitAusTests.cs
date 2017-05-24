using System;
using EventsUndDelegates.Geräte;
using EventsUndDelegates.Regeln;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Regeln
{
    [TestClass]
    public class LichtGehtNachZeitAusTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_SchalterNull_Exception()
        {
            var licht = new Lampenaktor();
            var regel = new LichtGehtNachZeitAus(licht, null);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_LichtNull_Exception()
        {
            var schalter = new Schalter();
            var regel = new LichtGehtNachZeitAus(null, schalter);
        }
    }
}
